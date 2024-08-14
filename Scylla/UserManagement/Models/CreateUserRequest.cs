using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class CreateUserRequest
    {
        [Required]
        public int Identification { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public List<CreateAddressRequest> Addresses { get; set; }

    }

    public class CreateAddressRequest
    {
        [Required]
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }

}
