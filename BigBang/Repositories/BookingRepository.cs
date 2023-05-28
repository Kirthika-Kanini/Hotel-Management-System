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
                return _bookingContext.Bookings.Include(x => x.Hotel).ToList();
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
                booking.CreatedDT = DateTime.UtcNow.ToString();

                var hotel = _bookingContext.Hotels.Find(booking.Hotel.HotelId);
                if (hotel == null)
                {
                    throw new Exception("Invalid hotel ID.");
                }

                var customer = _bookingContext.Customers
                    .Include(c => c.Hotel)
                    .FirstOrDefault(c => c.CustomerId == booking.Customer.CustomerId && c.Hotel.HotelId == hotel.HotelId);
                if (customer == null)
                {
                    throw new Exception("Customer is not associated with the specified hotel.");
                }

                var room = _bookingContext.Rooms
                    .Include(r => r.Hotel)
                    .FirstOrDefault(r => r.RoomId == booking.Room.RoomId && r.Hotel.HotelId == hotel.HotelId);
                if (room == null)
                {
                    throw new Exception("Room is not associated with the specified hotel.");
                }

                if (room.RoomCount > 0)
                {
                    room.RoomCount--;
                    _bookingContext.Entry(room).State = EntityState.Modified;
                    booking.Room = room;
                }
                else
                {
                    throw new Exception("No available rooms for booking.");
                }

                booking.Hotel = hotel;
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
                var booking = _bookingContext.Bookings.Include(b => b.Room).FirstOrDefault(b => b.BookingId == BookingId);

                if (booking != null)
                {
                    var room = booking.Room;

                    if (room != null)
                    {
                        room.RoomCount++;
                        _bookingContext.Entry(room).State = EntityState.Modified; 
                    }

                    _bookingContext.Bookings.Remove(booking);
                    _bookingContext.SaveChanges();

                    return booking;
                }
                else
                {
                    throw new Exception("Booking not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete booking.", ex);
            }
        }

    }
}
