using BigBang.Models;
using BigBang.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BigBang.Repositories
{
    public class CustomerRepository:ICustomer
    {
        private readonly HotelContext _customerContext;
        public CustomerRepository(HotelContext con)
        {
            _customerContext = con;
        }



        public IEnumerable<Customer> GetCustomer()
        {
            return _customerContext.Customers.ToList();
        }
        public Customer GetCustomerById(int CustomerId)
        {
            return _customerContext.Customers.FirstOrDefault(x => x.CustomerId == CustomerId);
        }

        public Customer PostCustomer(Customer customer)
        {

            var cus = _customerContext.Hotels.Find(customer.Hotel.HotelId);
            customer.Hotel = cus;
            _customerContext.Add(customer);
            _customerContext.SaveChanges();
            return customer;
        }

        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            var cus = _customerContext.Hotels.Find(customer.Hotel.HotelId);
            customer.Hotel = cus; ;
            _customerContext.Entry(customer).State = EntityState.Modified;
            _customerContext.SaveChangesAsync();
            return customer;
        }

        public Customer DeleteCustomer(int CustomerId)
        {

            var cus = _customerContext.Customers.Find(CustomerId);


            _customerContext.Customers.Remove(cus);
            _customerContext.SaveChanges();

            return cus;
        }
    }
}
