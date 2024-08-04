namespace Data.Entities.Company
{
    public class Company : BaseAuditCode
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }

        public bool IsActive { get; set; }
    }
}
