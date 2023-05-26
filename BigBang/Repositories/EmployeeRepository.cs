using BigBang.Models;
using Microsoft.EntityFrameworkCore;


namespace BigBang.Repositories
{
    public class EmployeeRepository:IEmployee
    {
       

            private readonly HotelContext _employeeContext;
            public EmployeeRepository(HotelContext con)
            {
                _employeeContext = con;
            }



            public IEnumerable<Employee> GetEmployees()
            {
                return _employeeContext.Employees.ToList();
            }
            public Employee GetEmployeesById(int EmployeeId)
            {
                return _employeeContext.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            }

            public Employee PostEmployee(Employee employee)
            {

                var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = emp;
            _employeeContext.Add(employee);
            _employeeContext.SaveChanges();
                return employee;
            }

            public Employee PutEmployee(int EmployeeId, Employee employee)
            {
                var emp = _employeeContext.Hotels.Find(employee.Hotel.HotelId);
                employee.Hotel = emp;
            _employeeContext.Entry(employee).State = EntityState.Modified;
            _employeeContext.SaveChangesAsync();
                return employee;
            }

            public Employee DeleteEmployee(int EmployeeId)
            {

                var emp = _employeeContext.Employees.Find(EmployeeId);


            _employeeContext.Employees.Remove(emp);
            _employeeContext.SaveChanges();

                return emp;
            }
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {
            var count = (from Room in _employeeContext.Rooms
                             join hotel in _employeeContext.Hotels on Room.Hotel.HotelId equals hotel.HotelId
                             where Room.RoomId == RoomId && hotel.HotelId == HotelId
                             select Room.RoomCount).FirstOrDefault();

            return count;
        }

      


    }
}
