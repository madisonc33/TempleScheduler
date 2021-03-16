using System;
using System.ComponentModel.DataAnnotations;

namespace TempleScheduler.Models
{
    public class TimeSlots
    {
        [Key]
        [Required]
        public int TimeId { get; set; }

        [Required]
        public DateTime AvailableTime { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
