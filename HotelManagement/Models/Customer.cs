using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CreatedDT { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
