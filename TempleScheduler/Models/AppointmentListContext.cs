using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    public class AppointmentListContext : DbContext
    {
        //this class inherits from the DbContext base classs and allows us to access the database through it
        public AppointmentListContext (DbContextOptions<AppointmentListContext> options) : base(options)
        {

        }

        //this creates a list of all the items in the database that can be referenced in the program
        public DbSet<Appointment> appointments { get; set; }
    }
}
