using Data.Entities;
using Shared.Models.Address;

namespace General.Models.Company
{
    public class CompanyResponse :BaseAuditCode
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int CompanyCode { get; set; }
        public bool IsActive { get; set; }
        public ICollection<GetAddressResponse> AddressList { get; set; } = [];

    }
}
