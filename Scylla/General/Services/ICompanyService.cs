using Data.Entities;
using General.Models.Company;

namespace General.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyResponse>> GetAll();
        Task<CreateCompanyResponse> Create(CreateCompanyRequest request);
        Task<bool> IsCompanyCreated(CreateCompanyRequest request);



    }
}
