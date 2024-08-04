using Data.Entities.Company;
using General.Models.Company;

namespace General.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();
        Task<CreateCompanyResponse> Create(CreateCompanyRequest request);
        Task<bool> IsCompanyCreated(CreateCompanyRequest request);



    }
}
