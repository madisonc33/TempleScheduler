using System;
using System.Collections.Generic;

namespace TempleScheduler.Models.ViewModels
{
    public class AvailableTasksViewModel
    {
        public IEnumerable<TimeSlots> AreAvailable { get; set; }

    }
}
