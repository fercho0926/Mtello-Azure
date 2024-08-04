using Data.Entities;

namespace General.Models.Company
{
    public class CreateCompanyRequest : BaseAuditCode
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
