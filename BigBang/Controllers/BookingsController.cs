using BigBang.Models;
using BigBang.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.Controllers
{
    [Authorize] 
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IBooking b;
        public BookingsController(IBooking b)
        {
            this.b = b;
        }
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return b.GetBooking();
        }

        [HttpGet("{BookingId}")]
        public Booking GetById(int BookingId)
        {
            return b.GetBookingById(BookingId);
        }

        [HttpPost]
        public Booking PostBooking(Booking booking)
        {
         
                return b.PostBooking(booking);
            
            
        }
        [HttpPut("{BookingId}")]
        public Booking PutBooking(int BookingId, Booking booking)
        {
            return b.PutBooking(BookingId, booking);
        }
        [HttpDelete("{BookingId}")]
        public Booking DeleteBooking(int BookingId)
        {
            return b.DeleteBooking(BookingId);
        }
    }
}
