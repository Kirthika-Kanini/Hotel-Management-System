using BigBang.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBang.Repositories
{
    public class BookingRepository : IBooking
    {
        private readonly HotelContext _bookingContext;

        public BookingRepository(HotelContext con)
        {
            _bookingContext = con;
        }

        public IEnumerable<Booking> GetBooking()
        {
            try
            {
                return _bookingContext.Bookings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve bookings.", ex);
            }
        }

        public Booking GetBookingById(int BookingId)
        {
            try
            {
                return _bookingContext.Bookings.FirstOrDefault(x => x.BookingId == BookingId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve booking by ID.", ex);
            }
        }

        public Booking PostBooking(Booking booking)
        {
            try
            {
                var b = _bookingContext.Hotels.Find(booking.Hotel.HotelId);
                booking.Hotel = b;
                var room = _bookingContext.Rooms.Find(booking.Room.RoomId);
                booking.Room = room;

                var customer = _bookingContext.Customers.Find(booking.Customer.CustomerId);
                booking.Customer = customer;

                _bookingContext.Add(booking);
                _bookingContext.SaveChanges();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create booking.", ex);
            }
        }

        public Booking PutBooking(int BookingId, Booking booking)
        {
            try
            {
                var r = _bookingContext.Hotels.Find(booking.Hotel.HotelId);
                booking.Hotel = r;
                _bookingContext.Entry(booking).State = EntityState.Modified;
                _bookingContext.SaveChanges();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update booking.", ex);
            }
        }

        public Booking DeleteBooking(int BookingId)
        {
            try
            {
                var b = _bookingContext.Bookings.Find(BookingId);
                _bookingContext.Bookings.Remove(b);
                _bookingContext.SaveChanges();
                return b;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete booking.", ex);
            }
        }
    }
}
