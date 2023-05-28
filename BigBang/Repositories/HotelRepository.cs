using System;
using System.Collections.Generic;
using System.Linq;
using BigBang.Models;
using BigBang.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
{
    public class HotelRepository : IHotel
    {
        private readonly HotelContext _hotelContext;

        public HotelRepository(HotelContext con)
        {
            _hotelContext = con;
        }

        public IEnumerable<Hotel> GetHotel()
        {
            try
            {
                return _hotelContext.Hotels.Include(x => x.Rooms).Include(x => x.Customers).ToList();
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error occurred while retrieving hotels.", ex);
            }
        }

        public Hotel GetHotelById(int HotelId)
        {
            try
            {
                return _hotelContext.Hotels.FirstOrDefault(x => x.HotelId == HotelId);
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Error occurred while retrieving hotel with ID {HotelId}.", ex);
            }
        }

        public Hotel PostHotel(Hotel hotel)
        {
            try
            {
                hotel.CreatedDT = DateTime.UtcNow.ToString();
                _hotelContext.Hotels.Add(hotel);
                _hotelContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
              
                throw new Exception("Error occurred while adding the hotel.", ex);
            }
        }

        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            try
            {
                _hotelContext.Entry(hotel).State = EntityState.Modified;
                _hotelContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
             
                throw new Exception($"Error occurred while updating hotel with ID {HotelId}.", ex);
            }
        }

        public Hotel DeleteHotel(int HotelId)
        {
            try
            {
                var hotel = _hotelContext.Hotels.Find(HotelId);
                if (hotel == null)
                {
                    throw new ArgumentException($"Hotel with ID {HotelId} does not exist.");
                }

                _hotelContext.Hotels.Remove(hotel);
                _hotelContext.SaveChanges();

                return hotel;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Error occurred while deleting hotel with ID {HotelId}.", ex);
            }
        }
    }
}

