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

        private AppointmentListContext AppointmentContext { get; set; }

        private TimeSlotListContext TimeContext { get; set; }

        public HomeController(ILogger<HomeController> logger, AppointmentListContext Acon, TimeSlotListContext Tcon)
        {
            _logger = logger;
            AppointmentContext = Acon;
            TimeContext = Tcon;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View(new AvailableTasksViewModel
            {
                AreAvailable = TimeContext.TimeSlots
                    .Where(x => x.IsAvailable ==true)
            });
        }

        [HttpGet]
        public IActionResult EnterInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterInfo(Appointment appoint)
        {
            if (ModelState.IsValid)
            {
                AppointmentContext.appointments.Add(appoint);
                AppointmentContext.SaveChanges();
            }
            return View("Index");
        }

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
