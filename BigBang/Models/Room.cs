using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int RoomCount { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
