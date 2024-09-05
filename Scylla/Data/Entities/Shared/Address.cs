using Data.Entities.UserManagement;
using System.ComponentModel.DataAnnotations;


namespace Data.Entities.Shared
{
    public class Address
    {
        public Guid AddressId { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string AddressLine { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }



        //Company Foreing Key
        public Guid? CompanyId { get; set; }
        public Company.Company Company { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }




    }
}
