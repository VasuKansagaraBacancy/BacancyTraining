using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }

}
