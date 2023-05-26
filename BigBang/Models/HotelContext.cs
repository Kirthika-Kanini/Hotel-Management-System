﻿using Microsoft.EntityFrameworkCore;

namespace BigBang.Models
{
    public class HotelContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }
    }
}
