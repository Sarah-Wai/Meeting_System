using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meeting_System.Models;

namespace Meeting_System.Data
{
    public class AddTestData
    {
        public static List<Room> getRoomData()
        {
            List<Room> rooms = new List<Room>();
            var testRoom1 = new Room
            {
                ID = "abc123",
                Name = "Luke",
                Location = "BTBetok"
            };

            rooms.Add(testRoom1);

            var testRoom2 = new Room
            {
                ID = "def456",
                Name = "Wai",
                Location = "AMKAMK"
            };

            rooms.Add(testRoom2);
            return rooms;
        }

    }
}

