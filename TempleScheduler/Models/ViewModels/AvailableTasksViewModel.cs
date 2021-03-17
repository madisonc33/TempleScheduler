using System;
using System.Collections.Generic;

namespace TempleScheduler.Models.ViewModels
{
    public class AvailableTasksViewModel
    {
        //creates a view model that makes it easy for us to iterate through the available times that we get using linq, then it's easy to sent to the model
        public IEnumerable<TimeSlots> AreAvailable { get; set; }

    }
}
