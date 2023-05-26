using BigBang.Models;

namespace BigBang.Repositories
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetCustomer();
        public Customer GetCustomerById(int CustomerId);
        public Customer PostCustomer(Customer customer);
        public Customer PutCustomer(int CustomerId, Customer customer);
        public Customer DeleteCustomer(int CustomerId);
        public IEnumerable<Hotel> FilterHotels(string HotelLocation);
        public IEnumerable<Hotel> FilterHotelsByAmenities(string HotelAmenities);
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId);

    }
}
