using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Address
{
    public class CreateAddressRequest
    {
        [Required]
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
