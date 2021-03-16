using System;
using System.ComponentModel.DataAnnotations;

namespace TempleScheduler.Models
{
    public class Apppointment
    {
        [Key]
        [Required]
        public int iAppointmentId { get; set; }

        [Required]
        public DateTime dApptTime { get; set; }

        [Required]
        public string sName { get; set; }

        [Required]
        public int iSize { get; set; }

        [Required]
        public string sEmail { get; set; }

        [Required]
        public int iPhoneNum { get; set; }
    }
}
