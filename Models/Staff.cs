using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFitnessStudio.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Required]
        public string StaffName { get; set; } = string.Empty;  // Default value

        public string StaffAddress { get; set; } = string.Empty;  // Default value

        [DataType(DataType.Date)]
        public DateTime StaffDOB { get; set; }
    }
}