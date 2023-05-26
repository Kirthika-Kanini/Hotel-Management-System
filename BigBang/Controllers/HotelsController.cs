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
    public class HotelsController : ControllerBase
    {

        private readonly IHotel h;
        public HotelsController(IHotel h)
        {
            this.h = h;
        }
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return h.GetHotel();
        }

        [HttpGet("{HotelId}")]
        public Hotel GetById(int HotelId)
        {
            return h.GetHotelById(HotelId);
        }

        [HttpPost]
        public Hotel PostHotel(Hotel hotel)
        {
            return h.PostHotel(hotel);
        }
        [HttpPut("{HotelId}")]
        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            return h.PutHotel(HotelId, hotel);
        }
        [HttpDelete("{HotelId}")]
        public Hotel DeleteHotel(int HotelId)
        {
            return h.DeleteHotel(HotelId);
        }
    }
}
