using System.ComponentModel.DataAnnotations;
using Data.Entities.Shared;

namespace Data.Entities
{
    public class Company : BaseAuditCode
    {
        public Guid CompanyId { get; set; }


        [MaxLength(100)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        [Required]

        public required string Email { get; set; }

        [Required]
        public int Phone { get; set; }

        public int CompanyCode { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Address> Address { get; set; } = [];



    }
}
