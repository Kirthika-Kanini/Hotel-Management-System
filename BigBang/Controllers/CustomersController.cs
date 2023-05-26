using BigBang.Models;
using BigBang.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomer cus;
        public CustomersController(ICustomer cus)
        {
            this.cus = cus;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cus.GetCustomer();
        }

        [HttpGet("{CustomerId}")]
        public Customer GetById(int CustomerId)
        {
            return cus.GetCustomerById(CustomerId);
        }

        [HttpPost]
        public Customer PostCustomer(Customer customer)
        {
            return cus.PostCustomer(customer);
        }
        [HttpPut("{CustomerId}")]
        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            return cus.PutCustomer(CustomerId, customer);
        }
        [HttpDelete("{CustomerId}")]
        public Customer DeleteCustomer(int CustomerId)
        {
            return cus.DeleteCustomer(CustomerId);
        }
        
        [HttpGet("filter")]
        public IEnumerable<Hotel> FilterHotels(string HotelLocation)
        {
            return cus.FilterHotels(HotelLocation);
        }
        [HttpGet("filterbyAmenities")]
         public IEnumerable<Hotel> FilterHotelsByAmenities(string HotelAmenities)
        {
            return cus.FilterHotelsByAmenities(HotelAmenities);
        }

        [HttpGet("roomcount")]
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {

            return cus.GetRoomCountByRoomIdAndHotelId(RoomId, HotelId);
        }

    }
}
