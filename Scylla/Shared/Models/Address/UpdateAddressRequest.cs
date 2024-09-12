using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Address
{
    public class UpdateAddressRequest
    {
        public Guid AddressId { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
