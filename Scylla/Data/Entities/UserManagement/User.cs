using System.ComponentModel.DataAnnotations;
using Data.Entities.Shared;

namespace Data.Entities.UserManagement
{
    public class User : BaseAuditCode
    {
        public Guid UserId { get; set; }

        public int Identification { get; set; }
        [MaxLength(50)]

        public required string FirstName { get; set; }
        [MaxLength(50)]

        public string? MiddleName { get; set; }
        [MaxLength(50)]

        public string? LastName { get; set; }
        [MaxLength(100)]
        [Required]

        public required string Email { get; set; }
        [MaxLength(20)]

        public int Phone { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Address> Address { get; set; } = [];


    }
}
