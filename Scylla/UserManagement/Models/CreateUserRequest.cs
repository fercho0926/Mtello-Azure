using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class CreateUserRequest
    {
        [Required]
        public required int Identification { get; set; }

        [Required]
        public  required string Email { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public  string? LastName { get; set; }
        [Required]
        public required string Password { get; set; }

    }
}
