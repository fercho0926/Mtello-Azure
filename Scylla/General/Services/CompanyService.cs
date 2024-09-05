using AutoMapper;
using Data;
using Data.Entities;
using Data.Entities.Shared;
using General.Models.Company;
using Microsoft.EntityFrameworkCore;

namespace General.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public CompanyService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CompanyResponse>> GetAll()
        {
            var companies  = await _appDbContext.Company.ToListAsync();

            var companyResponses = _mapper.Map<IEnumerable<CompanyResponse>>(companies);

            return companyResponses;
        }

        public async Task<CreateCompanyResponse> Create(CreateCompanyRequest request)
        {
            var newCompany = new Company
            {
                Email = request.Email,
                CompanyName = request.CompanyName,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                Phone = request.Phone,
                CompanyCode = request.CompanyCode,
                IsActive = true,
                Address = request.AddressList.Select(a => new Address
                {
                    AddressLine = a.AddressLine,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode
                }).ToList()
            };
            _appDbContext.Company.Add(newCompany);

            await _appDbContext.SaveChangesAsync();

            return new CreateCompanyResponse
            {
                CompanyId = newCompany.CompanyId

            };
        }
        public async Task<bool> IsCompanyCreated(CreateCompanyRequest request)
        {
            return await _appDbContext.Company.AnyAsync(u => u.CompanyName == request.CompanyName);
        }




    }

}
