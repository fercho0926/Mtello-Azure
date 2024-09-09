using Data;
using Data.Entities;
using Data.Entities.Shared;
using Data.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using Shared.Models.Address;
using System.Security.Cryptography;
using System.Text;
using UserManagement.Models;
using UserManagement.Models.User;

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
            return await _appDbContext.User.ToListAsync();
        }

        public async Task<GetUserByIdResponse> GetById(Guid userId)
        {
            var user = await _appDbContext.User
            .Include(uta => uta.Address)
            .SingleOrDefaultAsync(u => u.UserId == userId);

            var result = new GetUserByIdResponse
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                IsActive = user.IsActive,
                CreatedBy = user.CreatedBy,
                CreatedDate = user.CreatedDate,
                AddressList = user.Address.Select(a => new GetAddressResponse
                {
                    AddressId = a.AddressId,
                    AddressLine = a.AddressLine ?? "",
                    City = a.City ??"",
                    State = a.State ?? "",
                    PostalCode = a.PostalCode ?? ""
                }).ToList()
            };

            return result;
        }

        public async Task<CreateUserResponse> Create(CreateUserRequest request)
        {


            using var hmac = new HMACSHA512();


            const string createdBy = "OJO TRAER EL USUARIO";
            var createdDate = DateTime.UtcNow;


            var newUser = new User
            {
                Email = request.Email.ToLower(),
                FirstName = request.FirstName.ToLower(),
                MiddleName = request.MiddleName.ToLower(),
                LastName = request.LastName?.ToLower(),
                Phone = request.Phone,
                CreatedBy = createdBy,
                CreatedDate = createdDate,
                IsActive = true,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key,
                Address = request.AddressList.Select(a => new Address
                {
                    AddressLine = a.AddressLine,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode
                }).ToList()

            };


            //foreach (var addressRequest in request.AddressList)
            //{
            //    var address = new Address()
            //    {
            //        AddressLine = addressRequest.AddressLine,
            //        City = addressRequest.City,
            //        State = addressRequest.State,
            //        PostalCode = addressRequest.PostalCode,
          
            //    };

            //    var userToAddress = new UserToAddress
            //    {
            //        Users = user,
            //        Addresses = address

            //    };

            //    //user.UserToAddresses.Add(userToAddress);
            //    _appDbContext.Address.Add(address);
            //}

            _appDbContext.User.Add(newUser);
            await _appDbContext.SaveChangesAsync();

            return new CreateUserResponse
            {
                UserId = newUser.UserId,
            };

        }

        public async Task<bool> IsUserCreated(CreateUserRequest userRequest)
        {
            return await _appDbContext.User.AnyAsync(u => u.Email == userRequest.Email );
        }


        public async Task<bool> DeleteById(Guid id)
        {
            var user = await _appDbContext.User.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            //_appDbContext.Users.Remove(user);

            user.IsActive = false;
            _appDbContext.User.Update(user);
            await _appDbContext.SaveChangesAsync();

            return true; // User deleted successfully
        }




    }
}
