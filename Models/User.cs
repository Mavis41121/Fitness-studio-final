using System;
using System.ComponentModel.DataAnnotations;

namespace MyFitnessStudio.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; } = string.Empty;  // Default value

        [Required, MaxLength(100)]
        public string UserContacts { get; set; } = string.Empty;  // Default value

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = string.Empty;  // Default value
    }
}