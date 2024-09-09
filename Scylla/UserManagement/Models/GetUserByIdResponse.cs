using Data.Entities;
using Shared.Models.Address;

namespace UserManagement.Models
{
    public class GetUserByIdResponse : BaseAuditCode
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public bool IsActive { get; set; }
        public List<GetAddressResponse> AddressList { get; set; } = new();
    }

}
