using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_CORE_Day3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        [DefaultValue(false)]
        public bool IsVIP { get; set; }

        // Navigation
        public virtual  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}