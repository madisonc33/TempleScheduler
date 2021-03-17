using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleScheduler.Models;

namespace TempleScheduler.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EnterInfoModel : PageModel
    {
        private TimeSlotListContext Timecontext;

        private AppointmentListContext Apptcontext;

        public EnterInfoModel(TimeSlotListContext con, AppointmentListContext appt)
        {
            Timecontext = con;

            Apptcontext = appt;
        }

        public string ReturnUrl { get; set; }

        public DateTime ReserveTime { get; set; }

        public void OnGet(string returnUrl, int timeId) //pass through and pass thorugh as variable
        {
            var data = Timecontext.TimeSlots
                .Where(i => i.TimeId == timeId);
            foreach (var i in data)
            {
                ReserveTime = i.AvailableTime;
            }
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(string Time, string Name, int Size, string Email, int PhoneNum) //saves to DB
        {
            //Appointment appointment = context.appointments.FirstOrDefault(a => a.TimeId == timeId);
            var appt = new Appointment
            {
                ApptTime = DateTime.Parse(Time),
                Name = Name,
                Size = Size,
                Email = Email,
                PhoneNum = PhoneNum
            };
            Apptcontext.appointments.Add(appt);
            Apptcontext.SaveChanges();

            TimeSlots time = Timecontext.TimeSlots
                .FirstOrDefault(x => x.AvailableTime == appt.ApptTime);


            time.IsAvailable = false;
            Timecontext.SaveChanges();
            //foreach (var i in time)
            //{
            //    i.IsAvailable = false;
            //}

            return RedirectToPage("Index");
        }


    }


}
    

