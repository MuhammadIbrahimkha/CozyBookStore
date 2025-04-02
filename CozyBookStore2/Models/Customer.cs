using System.ComponentModel.DataAnnotations;

namespace CozyBookStore2.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string ZipCode { get; set; }

        // One to many relationship: Navigation property for orders

        public ICollection<Order> Orders { get; set; }
    }
}
