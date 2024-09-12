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
            return await _appDbContext.User
                .OrderByDescending(x=> x.CreatedDate)
                .ToListAsync();
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



        public async Task<bool> Update(UpdateUserRequest request)
        {
            // Retrieve the user including their addresses
            var user = await _appDbContext.User
                .Include(u => u.Address)
                .SingleOrDefaultAsync(u => u.UserId == request.UserId);

            if (user == null)
            {
                // Return false if the user is not found
                return false;
            }

            // Update user properties
            user.FirstName = request.FirstName?.ToLower() ?? user.FirstName;
            user.MiddleName = request.MiddleName?.ToLower() ?? user.MiddleName;
            user.LastName = request.LastName?.ToLower() ?? user.LastName;
            user.Email = request.Email?.ToLower() ?? user.Email;
            user.Phone = request.Phone ?? user.Phone;
            user.IsActive = request.IsActive;

            // Update addresses if provided
            if (request.AddressList != null)
            {
                // Create a dictionary of addresses from the request for quick lookup
                var addressDict = request.AddressList.ToDictionary(a => a.AddressId);

                // Create a list to hold new addresses
                var newAddresses = new List<Address>();

                // Update existing addresses
                foreach (var address in user.Address.ToList())
                {
                    if (addressDict.TryGetValue(address.AddressId, out var addressRequest))
                    {
                        address.AddressLine = addressRequest.AddressLine;
                        address.City = addressRequest.City;
                        address.State = addressRequest.State;
                        address.PostalCode = addressRequest.PostalCode;

                        // Remove the address from the dictionary after updating
                        addressDict.Remove(address.AddressId);
                    }
                }

                // Add new addresses that are not in the existing address list
                foreach (var addressRequest in addressDict.Values)
                {
                    var newAddress = new Address
                    {
                        AddressId = addressRequest.AddressId,
                        AddressLine = addressRequest.AddressLine,
                        City = addressRequest.City,
                        State = addressRequest.State,
                        PostalCode = addressRequest.PostalCode
                    };
                    newAddresses.Add(newAddress);
                }

                // Add the new addresses to the user's address list
                if (newAddresses.Any())
                {
                    foreach (var newAddress in newAddresses)
                    {
                        user.Address.Add(newAddress);
                    }
                }
            }

            // Mark the user entity as modified
            _appDbContext.User.Update(user);

            // Save changes to the database
            await _appDbContext.SaveChangesAsync();

            return true;
        }


        //public async Task<bool> Update(UpdateUserRequest request)
        //{
        //    var user = await _appDbContext.User
        //        .Include(u => u.Address) // Include addresses if you need to update them
        //        .SingleOrDefaultAsync(u => u.UserId == request.UserId);

        //    if (user == null)
        //        return false;

        //    // Update user properties





        //    user.FirstName = request.FirstName.ToLower();
        //    user.MiddleName = request.MiddleName.ToLower();
        //    user.LastName = request.LastName?.ToLower();
        //    user.Email = request.Email.ToLower();
        //    user.Phone = request.Phone;
        //    user.IsActive = request.IsActive;

        //    // Optionally update the address list if it exists
        //    if (request.AddressList != null)
        //    {
        //        // You might want to clear the existing addresses and add new ones or update them based on your logic
        //        user.Address.Clear();
        //        user.Address.AddRange(request.AddressList.Select(a => new Address
        //        {
        //            AddressId = a.AddressId,
        //            AddressLine = a.AddressLine,
        //            City = a.City,
        //            State = a.State,
        //            PostalCode = a.PostalCode
        //        }));
        //    }

        //    _appDbContext.User.Update(user);
        //    await _appDbContext.SaveChangesAsync();

        //    return true; // User updated successfully
        //}
    }





}
