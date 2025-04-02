using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CozyBookStore2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public string PaymentTransactionId { get; set; } // Store the payment transaction ID from Stripe

        // Foreign key for Customer (One-to-Many relationship)
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
