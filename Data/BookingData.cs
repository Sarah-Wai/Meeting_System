using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meeting_System.Controllers;
using Meeting_System.Models;

namespace Meeting_System.Data
{
    public class BookingData
    {
        //Get ALl Active Booking List
        public static List<dynamic> GetActiveBooking(MyDBContext context123, ILogger<HomeController> logger)
        {
            logger.LogInformation("Get All Active Booking");
            List<Booking> bookingList = context123.Bookings.ToList();
            List<Room> roomList = context123.Rooms.ToList();

            var iter = (from r in bookingList
                        where r.status == true
                        join rd in roomList on r.RoomID equals rd.ID
                        select new
                        {
                            BookID = r.ID,
                            Location=rd.Location,
                            RoomName = rd.Name,
                            StartTime = r.ReservationStartTime.ToString(),
                            EndTime = r.ReservationEndTime.ToString()

                        }).ToList();
            List<dynamic> test = new List<dynamic>();
            foreach (var i in iter)
            {
                test.Add(i);
            }


            return test;
        }

        //Saving Booking Data to Database
        public static string AddBooking(MyDBContext context123, Booking book, ILogger<HomeController> logger)
        {
            string log_message = "";
            //Checking Booking Room is Available 
            //if available , save to DB and write to log file
            //if not , return Unavailabe message to view and write to log file
            List<Booking> bookingList = context123.Bookings.ToList();
            Booking recent_booking = context123.Bookings
                            .Where(x => x.RoomID == book.RoomID &&
                            (book.ReservationStartTime >= x.ReservationStartTime && book.ReservationStartTime <= x.ReservationEndTime)
                            
                ).FirstOrDefault();

            if (recent_booking != null)
            {
                log_message = $"Booking Room {book.RoomID} is not available. ";
                logger.LogInformation(log_message);
                return "Meeting Room is  unavailable.Please choose another!";
            }
            else
            {
                book.ID = Guid.NewGuid().ToString();
                book.status = true;
                context123.Bookings.Add(book);
                try
                {
                    context123.SaveChanges();

                    log_message = $"{book.RoomID} is Successfull booked.";
                    logger.LogInformation(log_message);
                    return "Success";
                }
                catch (Exception ex)
                {
                    log_message = $"Fail at AddBooking -> {ex.Message.ToString()}";
                    logger.LogInformation(log_message);
                    return "Fail";

                }
            }

        }
        public static bool CancelBooking(MyDBContext context123, string bookingID, ILogger<HomeController> logger)
        {
            Booking recent_book = context123.Bookings.Where(x => x.ID == bookingID).FirstOrDefault();
           
            if (recent_book != null)
            {
                recent_book.status = false;

            }

            try
            {
                context123.SaveChanges();
                string log_message = $"{recent_book.ID} is canceled booking on {DateTime.Now}";
                logger.LogInformation(log_message);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }

        }
    }
}

