using BigBang.Models;
using BigBang.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class HotelRepository:IHotel
    {
        private readonly HotelContext _hotelContext;
        public HotelRepository(HotelContext con)
        {
            _hotelContext = con;
        }
        public IEnumerable<Hotel> GetHotel()
        {
            return _hotelContext.Hotels.Include(x => x.Rooms).ToList();
        }
        public Hotel GetHotelById(int HotelId)
        {
            return _hotelContext.Hotels.FirstOrDefault(x => x.HotelId == HotelId);
        }

        public Hotel PostHotel(Hotel hotel)
        {


            _hotelContext.Hotels.Add(hotel);
            _hotelContext.SaveChanges();
            return hotel;
        }

        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            
            _hotelContext.Entry(hotel).State = EntityState.Modified;
            _hotelContext.SaveChangesAsync();
            return hotel;
        }

        public Hotel DeleteHotel(int HotelId)
        {

            var hot = _hotelContext.Hotels.Find(HotelId);


            _hotelContext.Hotels.Remove(hot);
            _hotelContext.SaveChanges();

            return hot;
        }

    }
}
