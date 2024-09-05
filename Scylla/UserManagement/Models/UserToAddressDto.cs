namespace UserManagement.Models
{
    public class UserToAddressDto
    {
        public Guid UserToAddressId { get; set; }
        public Guid AddressesId { get; set; }
        public AddressDto Address { get; set; } = new();
    }

}
