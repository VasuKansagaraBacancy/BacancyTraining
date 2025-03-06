using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Course { get; set; }
    }
}
