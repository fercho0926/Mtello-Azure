namespace Data.Entities.UserManagement
{
    public class UserToAddress
    {
        public Guid UserToAddressId { get; set; }

        public Guid UserId { get; set; }
        public User Users { get; set; }

        public Guid AddressesId { get; set; }
        public Addresses Addresses { get; set; }


    }
}
