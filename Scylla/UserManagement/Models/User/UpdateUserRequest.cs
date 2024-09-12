using Shared.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.User
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? UpdatedBy { get; set; }



        public bool IsActive { get; set; }

        public List<UpdateAddressRequest>? AddressList { get; set; }

    }
}
