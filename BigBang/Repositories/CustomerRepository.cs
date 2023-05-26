using BigBang.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BigBang.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly HotelContext _customerContext;

        public CustomerRepository(HotelContext con)
        {
            _customerContext = con;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            try
            {
                return _customerContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customers.", ex);
            }
        }

        public Customer GetCustomerById(int CustomerId)
        {
            try
            {
                return _customerContext.Customers.FirstOrDefault(x => x.CustomerId == CustomerId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customer by ID.", ex);
            }
        }

        public Customer PostCustomer(Customer customer)
        {
            try
            {
                var cus = _customerContext.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = cus;
                _customerContext.Add(customer);
                _customerContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create customer.", ex);
            }
        }

        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            try
            {
                var cus = _customerContext.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = cus;
                _customerContext.Entry(customer).State = EntityState.Modified;
                _customerContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update customer.", ex);
            }
        }

        public Customer DeleteCustomer(int CustomerId)
        {
            try
            {
                var cus = _customerContext.Customers.Find(CustomerId);
                _customerContext.Customers.Remove(cus);
                _customerContext.SaveChanges();
                return cus;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete customer.", ex);
            }
        }
        public IEnumerable<Hotel> FilterHotels(string HotelLocation)
        {
            var filteredHotels = _customerContext.Hotels.AsQueryable();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(HotelLocation))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelLocation.Contains(HotelLocation));
            }



            return filteredHotels.ToList();
        }

        public IEnumerable<Hotel> FilterHotelsByAmenities(string HotelAmenities)
        {
            var filteredHotels = _customerContext.Hotels.AsQueryable();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(HotelAmenities))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelAmenities.Contains(HotelAmenities));
            }



            return filteredHotels.ToList();
        }
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {
            try
            {
                var count = (from room in _customerContext.Rooms
                             join hotel in _customerContext.Hotels on room.Hotel.HotelId equals hotel.HotelId
                             where room.RoomId == RoomId && hotel.HotelId == HotelId
                             select room.RoomCount).FirstOrDefault();

                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get room count by RoomId and HotelId.", ex);
            }
        }
    }
}
