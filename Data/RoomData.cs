using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meeting_System.Models;

namespace Meeting_System.Data
{
    public class RoomData
    {
        public static List<Room> GetAllRooms(MyDBContext context123)
        {
            List<Room> rooms = context123.Rooms.ToList();
            return rooms;
        }
    }
}
