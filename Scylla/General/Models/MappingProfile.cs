using AutoMapper;
using General.Models.Company;

namespace General.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Entities.Company, CompanyResponse>();
        }
    }
}
