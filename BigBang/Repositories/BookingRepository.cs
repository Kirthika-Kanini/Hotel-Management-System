using BigBang.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBang.Repositories
{
    public class BookingRepository:IBooking
    {
        private readonly HotelContext _bookingContext;
        public BookingRepository(HotelContext con)
        {
            _bookingContext = con;
        }



        public IEnumerable<Booking> GetBooking()
        {
            return _bookingContext.Bookings.ToList();
        }
        public Booking GetBookingById(int BookingId)
        {
            return _bookingContext.Bookings.FirstOrDefault(x => x.BookingId == BookingId);
        }

        public Booking PostBooking(Booking booking)
        {

            var b = _bookingContext.Hotels.Find(booking.Hotel.HotelId);
            booking.Hotel = b;
            _bookingContext.Add(booking);
            _bookingContext.SaveChanges();
            return booking;
        }

        public Booking PutBooking(int BookingId, Booking booking)
        {
            var r = _bookingContext.Hotels.Find(booking.Hotel.HotelId);
            booking.Hotel = r;
            _bookingContext.Entry(booking).State = EntityState.Modified;
            _bookingContext.SaveChangesAsync();
            return booking;
        }

        public Booking DeleteBooking(int BookingId)
        {

            var b = _bookingContext.Bookings.Find(BookingId);


            _bookingContext.Bookings.Remove(b);
            _bookingContext.SaveChanges();

            return b;
        }
    }
}
