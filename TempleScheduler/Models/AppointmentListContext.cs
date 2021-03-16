using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    public class AppointmentListContext : DbContext
    {
        public AppointmentListContext (DbContextOptions<AppointmentListContext> options) : base(options)
        {

        }

        public DbSet<Appointment> appointments { get; set; }
    }
}
