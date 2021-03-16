using System;
using System.ComponentModel.DataAnnotations;

namespace TempleScheduler.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime ApptTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNum { get; set; }
    }
}
