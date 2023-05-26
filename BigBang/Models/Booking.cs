using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookedDate { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOut { get; set; }
        public string? CreatedDT { get; set; }
        public Hotel? Hotel { get; set; }
        public Room? Room { get; set; }
        public Customer? Customer { get; set; }
        public Booking()
        {
            BookedDate = DateTime.Now;
        }
    }
}
