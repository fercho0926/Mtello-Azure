using Shared.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.User
{
    public class CreateUserRequest
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int Phone { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public List<CreateAddressRequest> AddressList { get; set; }

    }

}
