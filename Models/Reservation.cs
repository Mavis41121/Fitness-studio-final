using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFitnessStudio.Models
{
    public class Reservation
    {
        [Key]
        public int ReserID { get; set; }

        [ForeignKey("Session")]
        public int SessionID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public virtual Session Session { get; set; }  // Nullable
        public virtual Client Client { get; set; }  // Nullable

        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }
    }
}