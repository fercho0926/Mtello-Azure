using Data.Entities;
using Shared.Models.Address;

namespace General.Models.Company
{
    public class CreateCompanyRequest : BaseAuditCode
    {
        public string CompanyName { get; set; }
        public required string Email { get; set; }
        public int Phone { get; set; }
        public int CompanyCode { get; set; }

        public ICollection<CreateAddressRequest> AddressList { get; set; }




    }
}
