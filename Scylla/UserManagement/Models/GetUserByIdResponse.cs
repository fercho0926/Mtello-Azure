using Data.Entities;

namespace UserManagement.Models
{
    public class GetUserByIdResponse : BaseAuditCode
    {
        public Guid UserId { get; set; }
        public int Identification { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public List<UserToAddressDto> UserToAddresses { get; set; } = new();
    }

}
