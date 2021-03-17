using System;
using System.ComponentModel.DataAnnotations;

//Creates a Model for the TimeSlots Available
namespace TempleScheduler.Models
{
    public class TimeSlots
    {
        [Key] //Unique Key
        [Required]
        public int TimeId { get; set; }

        [Required]
        public DateTime AvailableTime { get; set; }

        [Required] //If True, will be displayed on the Signup.cshtml page. Change to false through page model after selected
        public bool IsAvailable { get; set; }
    }
}
