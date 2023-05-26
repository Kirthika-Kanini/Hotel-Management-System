using BigBang.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBang.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly HotelContext _employeeContext;

        public EmployeeRepository(HotelContext con)
        {
            _employeeContext = con;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _employeeContext.Employees.Include(x => x.Hotel).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve employees.", ex);
            }
        }

        public Employee GetEmployeesById(int EmployeeId)
        {
            try
            {
                return _employeeContext.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve employee by ID.", ex);
            }
        }

        public Employee PostEmployee(Employee employee)
        {
            try
            {
                employee.CreatedDT = DateTime.UtcNow.ToString();
                var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = emp;
                _employeeContext.Add(employee);
                _employeeContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create employee.", ex);
            }
        }

        public Employee PutEmployee(int EmployeeId, Employee employee)
        {
            try
            {
                var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = emp;
                _employeeContext.Entry(employee).State = EntityState.Modified;
                _employeeContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update employee.", ex);
            }
        }

        public Employee DeleteEmployee(int EmployeeId)
        {
            try
            {
                var emp = _employeeContext.Employees.Find(EmployeeId);
                _employeeContext.Employees.Remove(emp);
                _employeeContext.SaveChanges();
                return emp;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete employee.", ex);
            }
        }

        public string GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {
            try
            {
                var count = (from room in _employeeContext.Rooms
                             join hotel in _employeeContext.Hotels on room.Hotel.HotelId equals hotel.HotelId
                             where room.RoomId == RoomId && hotel.HotelId == HotelId
                             select room.RoomCount).FirstOrDefault();

                return "Number of rooms available are: " + count;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get room count by RoomName and HotelId.", ex);
            }
        }
    }
}
