using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medicare__.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required, StringLength(50, ErrorMessage = "Role name cannot exceed 50 characters.")]
        public string RoleName { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}
