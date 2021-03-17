using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TempleScheduler.Models;
using TempleScheduler.Models.ViewModels;

namespace TempleScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //creates a context variable for both tables in the database so that we can access the data in the tables throughout the program
        private AppointmentListContext AppointmentContext { get; set; }
        private TimeSlotListContext TimeContext { get; set; }

        //when built it initializes these variables and gets the data from the DB
        public HomeController(ILogger<HomeController> logger, AppointmentListContext Acon, TimeSlotListContext Tcon)
        {
            _logger = logger;
            AppointmentContext = Acon;
            TimeContext = Tcon;
        }

        //returns the index page when opened
        public IActionResult Index()
        {
            return View();
        }

        //when called it creates a new instance of the AvailablesTasks View Model. Inside this instance we use linq to only get the timeslots that are available (are true in the DB)
        public IActionResult SignUp()
        {
            return View(new AvailableTasksViewModel
            {
                AreAvailable = TimeContext.TimeSlots
                    .Where(x => x.IsAvailable ==true)
            });
        }

        //when called it sends the appointments data from the ViewAppointments view so that the appointments can be iterated through and displayed
        public IActionResult ViewAppointments()
        {
            return View(AppointmentContext);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
