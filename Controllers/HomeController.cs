using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Meeting_System.Data;
using Meeting_System.Models;

namespace Meeting_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MyDBContext context123;
        public HomeController(ILogger<HomeController> logger, MyDBContext context123)
        {
            _logger = logger;
            this.context123 = context123;
        }

        public IActionResult Index(string message)
        {
            List<dynamic> bookings = BookingData.GetActiveBooking(context123, _logger);
            List<Room> rooms = RoomData.GetAllRooms(context123);

            ViewData["bookings"] = bookings;
            ViewData["rooms"] = rooms;
            ViewData["msg"] = TempData["msg"];

            return View();
        }

        [HttpPost]

        public IActionResult BookRoom(string roomID,string startTime,string endTime)  //[FromBody]Booking book
        {
            DateTime startDate = startTime != null ? Convert.ToDateTime(startTime) : DateTime.Now;
            DateTime endDate = startTime != null ? Convert.ToDateTime(endTime) : DateTime.Now;
            if (roomID == null)
            {
                TempData["msg"] = "Please choose Room!";
            }
            else
            {
                Booking booking = new Booking()
                {
                    RoomID = roomID,
                    ReservationEndTime = endDate,
                    ReservationStartTime = startDate

                };

                string result = BookingData.AddBooking(context123, booking, _logger);
                TempData["msg"] = result;
            }

            return RedirectToAction("Index", "Home");
        }


        public IActionResult CancelBooking(string id)
        {

            BookingData.CancelBooking(context123, id, _logger);
            TempData["msg"] = "Cancled Successfully!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

