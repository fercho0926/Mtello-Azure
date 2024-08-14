using Data;
using Data.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITokenService _tokenService;

        public UserService(AppDbContext appDbContext, ITokenService tokenService)
        {
            _appDbContext = appDbContext;
            _tokenService = tokenService;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<UserDTO> Create(CreateUserRequest request)
        {
            {

                using var hmac = new HMACSHA512();


                const string createdBy = "OJO TRAER EL USUARIO LOGUEADO";
                var createdDate = DateTime.UtcNow;


                var user = new User
                {
                    Identification = request.Identification,
                    Email = request.Email.ToLower(),
                    FirstName = request.FirstName.ToLower(),
                    MiddleName = request.MiddleName.ToLower(),
                    LastName = request.LastName?.ToLower(),
                    Phone = request.Phone.ToLower(),
                    CreatedBy = createdBy,
                    CreatedDate = createdDate,
                    IsActive = true,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key,

                };


                foreach (var addressRequest in request.Addresses)
                {
                    var address = new Addresses()
                    {
                        Address = addressRequest.Address,
                        City = addressRequest.City,
                        State = addressRequest.State,
                        PostalCode = addressRequest.PostalCode,
                        CreatedBy = createdBy,
                        CreatedDate = createdDate,
                    };

                    var userToAddress = new UserToAddress
                    {
                        Users = user,
                        Addresses = address

                    };

                    user.UserToAddresses.Add(userToAddress);
                    _appDbContext.Addresses.Add(address);
                }

                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();

                return new UserDTO
                {
                    Email = user.Email,
                    Token = _tokenService.createToken(user)
                };
            }
        }

        public async Task<bool> IsUserCreated(CreateUserRequest userRequest)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Email == userRequest.Email || u.Identification == userRequest.Identification);
        }




    }
}
