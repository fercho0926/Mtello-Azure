namespace UserManagement.Models
{
    public class AddressDto
    {
        public Guid AddressesId { get; set; }
        public string Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }

}
