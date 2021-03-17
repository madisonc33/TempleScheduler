using System;
using Microsoft.EntityFrameworkCore;

namespace TempleScheduler.Models
{
    //List inherits from the Database, used to query and save
    public class TimeSlotListContext : DbContext
    {

        public TimeSlotListContext (DbContextOptions<TimeSlotListContext> options) : base(options)
        {

        }

        //Set the database to pull Timeslot info
        public DbSet<TimeSlots> TimeSlots { get; set; }
    }
}
