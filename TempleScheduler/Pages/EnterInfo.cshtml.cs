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

        public void OnGet(string returnUrl, DateTime AvailableTime) //pass through and pass thorugh as variable
        {
            ReserveTime = (DateTime)context.TimeSlots
                .Where(i => i.TimeId == AvailableTime);
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int timeId, string returnUrl) //saves to DB
        {
            //Appointment appointment = context.appointments.FirstOrDefault(a => a.TimeId == timeId);

            //took out from ch 9
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            //context.AddItem(appointment, 1);

            //took out from ch 9
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }


    }


}
    

