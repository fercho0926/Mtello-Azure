namespace General.Models.Company
{
    public class CreateCompanyResponse
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CreatedBy { get; set; }
    }
}
