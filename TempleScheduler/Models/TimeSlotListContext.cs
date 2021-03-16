using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    public class TimeSlotListContext : DbContext
    {
        public TimeSlotListContext (DbContextOptions<TimeSlotListContext> options) : base(options)
        {

        }

        public DbSet<TimeSlots> TimeSlots { get; set; }
    }
}
