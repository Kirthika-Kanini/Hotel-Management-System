﻿using BigBang.Models;
using BigBang.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.Controllers
{
    [Authorize]
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
        public string GetRoomCountByRoomIdAndHotelId(string RoomName, int HotelId)
        {

            return cus.GetRoomCount(RoomName, HotelId);
        }

        [HttpGet("rooms/price-range")]
        public IEnumerable<Room> GetRoomsByPriceRange(int minPrice, int maxPrice)
        {
            return cus.GetRoomsByPriceRange(minPrice, maxPrice);
        }

    }
}
