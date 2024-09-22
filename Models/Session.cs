using System;

namespace MyFitnessStudio.Models
{
    public class Session
    {
        public int SessionID { get; set; }

        public string SessionName { get; set; } = string.Empty; 
        public DateTime SessionDate { get; set; } 

        public TimeSpan Duration { get; set; }  
    }
}