using System;
using System.ComponentModel.DataAnnotations;

namespace TempleScheduler.Models
{
    public class Appointment
    {
        //this model matches with the DB table appointments and keeps track of all the data we want. They are all required.
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
