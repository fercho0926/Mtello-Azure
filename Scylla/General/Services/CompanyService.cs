using Data;
using Data.Entities.Company;
using General.Models.Company;
using Microsoft.EntityFrameworkCore;

namespace General.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _appDbContext;

        public CompanyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _appDbContext.Companies.ToListAsync();
        }

        public async Task<CreateCompanyResponse> Create(CreateCompanyRequest request)
        {
            var newCompany = new Company
            {
                CompanyId = new Guid(),
                CompanyName = request.CompanyName,
                CreatedBy = "Milton",
                CreatedDate = DateTime.Now,
                IsActive = true,
            };

            _appDbContext.Companies.Add(newCompany);
            await _appDbContext.SaveChangesAsync();
            return new CreateCompanyResponse()
            {
                CompanyId = newCompany.CompanyId,
                CompanyName = newCompany.CompanyName,
                CreatedBy = newCompany.CreatedBy
            };
        }

        //public async Task<UserDTO> Create(CreateUserRequest request)
        //{
        //    {

        //        using var hmac = new HMACSHA512();


        //        var user = new User
        //        {
        //            UserId = new Guid(),
        //            FirstName = request.FirstName.ToLower(),
        //            LastName = "vasquez",
        //            Identification = request.Identification,
        //            CreatedBy = "MIlton",
        //            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
        //            PasswordSalt = hmac.Key,
        //            Email = request.Email

        //        };

        //        _appDbContext.Users.Add(user);
        //        await _appDbContext.SaveChangesAsync();
        //        return new UserDTO
        //        {
        //            Email = user.Email,
        //            Token = _tokenService.createToken(user)
        //        };
        //    }
        //}

        public async Task<bool> IsCompanyCreated(CreateCompanyRequest request)
        {
            return await _appDbContext.Companies.AnyAsync(u => u.CompanyName == request.CompanyName);
        }




    }

}
