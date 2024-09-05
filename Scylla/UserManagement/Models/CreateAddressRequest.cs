using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class CreateAddressRequest
    {
        [Required]
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }

}
