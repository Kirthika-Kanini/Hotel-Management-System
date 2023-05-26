using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int RoomCount { get; set; }
        public int RoomPrice { get; set; }
        public string? CreatedDT { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
