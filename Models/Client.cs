using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFitnessStudio.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;  // Default value

        public string ClientAddress { get; set; } = string.Empty;  // Default value

        [DataType(DataType.Date)]
        public DateTime ClientDOB { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();  // Default initialization
    }
}