using BigBang.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BigBang.Repositories
{
    public class RoomRepository : IRoom
    {
        private readonly HotelContext _roomContext;

        public RoomRepository(HotelContext con)
        {
            _roomContext = con;
        }

        public IEnumerable<Room> GetRoom()
        {
            try
            {
                return _roomContext.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve rooms.", ex);
            }
        }

        public Room GetRoomById(int RoomId)
        {
            try
            {
                return _roomContext.Rooms.FirstOrDefault(x => x.RoomId == RoomId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve room by ID.", ex);
            }
        }

        public Room PostRoom(Room room)
        {
            try
            {
                room.CreatedDT = DateTime.UtcNow.ToString();
                var r = _roomContext.Hotels.Find(room.Hotel.HotelId);
                room.Hotel = r;
                _roomContext.Add(room);
                _roomContext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create room.", ex);
            }
        }

        public Room PutRoom(int RoomId, Room room)
        {
            try
            {
                var r = _roomContext.Hotels.Find(room.Hotel.HotelId);
                room.Hotel = r;
                _roomContext.Entry(room).State = EntityState.Modified;
                _roomContext.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update room.", ex);
            }
        }

        public Room DeleteRoom(int RoomId)
        {
            try
            {
                var r = _roomContext.Rooms.Find(RoomId);
                _roomContext.Rooms.Remove(r);
                _roomContext.SaveChanges();
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete room.", ex);
            }
        }
    }
}
