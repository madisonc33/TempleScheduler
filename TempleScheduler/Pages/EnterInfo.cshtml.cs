using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleScheduler.Models;

namespace TempleScheduler.Pages
{
    //the post method wasn't getting called and we were getting a HTTP 400 error. We found online that is was probably because it was looking for a Anti-forgery token to allows access and prevent attacks.
    //This statement allows us to ignore this request for token and makes it so we can call the post method
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EnterInfoModel : PageModel
    {
        //makes it so we can access the data in the database
        private TimeSlotListContext Timecontext;
        private AppointmentListContext Apptcontext;

        //initializes these variables
        public EnterInfoModel(TimeSlotListContext con, AppointmentListContext appt)
        {
            Timecontext = con;

            Apptcontext = appt;
        }

        public string ReturnUrl { get; set; }

        //variable to store and pass the time that the user wants make an appointment for
        public DateTime ReserveTime { get; set; }

        //get method that gets called when the user clicks "reserve" on the sign up page. This takes in the ID of the time the user wants to register and sets it to our public variable so that it can be used in the post
        public void OnGet(string returnUrl, int timeId)
        {
            //gets the timeslot where the ID's match and assigns it to the reserve time
            var data = Timecontext.TimeSlots
                .Where(i => i.TimeId == timeId);
            foreach (var i in data)
            {
                ReserveTime = i.AvailableTime;
            }
            ReturnUrl = returnUrl ?? "/";
        }

        //this method is called when the user posts the appointment online. It takes in the data and creates a new instance of an appointment that is then added and saved to the DB
        public IActionResult OnPost(string Time, string Name, int Size, string Email, string PhoneNum) //saves to DB
        {
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

            //this then gets the time that the user successfully signed up for and changes it to not available so that 2 users can't sign up for the same time.
            TimeSlots time = Timecontext.TimeSlots
                .FirstOrDefault(x => x.AvailableTime == appt.ApptTime);

            time.IsAvailable = false;
            Timecontext.SaveChanges();
            //foreach (var i in time)
            //{
            //    i.IsAvailable = false;
            //}

            //takes the user back to the home when they submit
            return RedirectToPage("Index");
        }


    }


}
    

