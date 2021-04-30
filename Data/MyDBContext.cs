using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meeting_System.Models;

namespace Meeting_System.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {

        }

        public MyDBContext()
        {

        }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}
