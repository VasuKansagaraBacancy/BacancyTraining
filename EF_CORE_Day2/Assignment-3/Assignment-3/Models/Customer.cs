using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
