using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_System.Models
{
    public class Booking
    {

        public string ID { get; set; }

        public string RoomID { get; set; }
        public bool status { get; set; }
        public DateTime ReservationStartTime { get; set; }
        public DateTime ReservationEndTime { get; set; }
    }
   
}
