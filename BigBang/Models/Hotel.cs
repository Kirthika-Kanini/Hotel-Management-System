using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }    
        public string? HotelName { get; set;}
        public string? HotelLocation { get; set;}
        public string? HotelAmenities { get; set;}
        public string? CreatedDT { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
