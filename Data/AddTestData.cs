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
                ID = Guid.NewGuid().ToString(),
                Name = "Room1",
                Location = "Building1"
            };

            rooms.Add(testRoom1);

            var testRoom2 = new Room
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Room2",
                Location = "Building1"
            };

            rooms.Add(testRoom2);
            var testRoom3 = new Room
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Room1",
                Location = "Building2"
            };

            rooms.Add(testRoom3);
            var testRoom4 = new Room
            {
                ID = Guid.NewGuid().ToString(),
                Name = "Room2",
                Location = "Building2"
            };

            rooms.Add(testRoom4);
            return rooms;
        }

    }
}

