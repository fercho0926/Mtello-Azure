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

        public async Task<GetUserByIdResponse> GetById(Guid userId)
        {
            var user = await _appDbContext.Users
            .Include(u => u.UserToAddresses)
            .ThenInclude(uta => uta.Addresses)
            .SingleOrDefaultAsync(u => u.UserId == userId);

            var result = new GetUserByIdResponse
            {
                UserId = user.UserId,
                Identification = user.Identification,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                IsActive = user.IsActive,
                CreatedBy = user.CreatedBy,
                CreatedDate = user.CreatedDate,
                UserToAddresses = user.UserToAddresses.Select(uta => new UserToAddressDto
                {
                    UserToAddressId = uta.UserToAddressId,
                    AddressesId = uta.AddressesId,
                    Address = new AddressDto
                    {
                        AddressesId = uta.Addresses.AddressesId,
                        Address = uta.Addresses.Address,
                        City = uta.Addresses.City,
                        State = uta.Addresses.State,
                        PostalCode = uta.Addresses.PostalCode
                    }
                }).ToList()
            };

            return result;
        }

        public async Task<UserDTO> Create(CreateUserRequest request)
        {


            using var hmac = new HMACSHA512();


            const string createdBy = "OJO TRAER EL USUARIO";
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

        public async Task<bool> IsUserCreated(CreateUserRequest userRequest)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Email == userRequest.Email || u.Identification == userRequest.Identification);
        }


        public async Task<bool> DeleteById(Guid id)
        {
            var user = await _appDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            //_appDbContext.Users.Remove(user);

            user.IsActive = false;
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();

            return true; // User deleted successfully
        }




    }
}
