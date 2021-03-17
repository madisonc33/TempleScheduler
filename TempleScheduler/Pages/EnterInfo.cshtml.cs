using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleScheduler.Models;

namespace TempleScheduler.Pages
{
    public class EnterInfoModel : PageModel
    {
        private TimeSlotListContext context;

        public EnterInfoModel(TimeSlotListContext con)
        {
            context = con;
        }

        public string ReturnUrl { get; set; }

        public DateTime ReserveTime { get; set; }

        public void OnGet(string returnUrl, int timeId) //pass through and pass thorugh as variable
        {
            var data = context.TimeSlots
                .Where(i => i.TimeId == timeId);
            foreach (var i in data)
            {
                ReserveTime = i.AvailableTime;
            }
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(Appointment appt) //saves to DB
        {
            //Appointment appointment = context.appointments.FirstOrDefault(a => a.TimeId == timeId);
            context.Add(appt);

            return RedirectToPage("index");
        }


    }


}
    

