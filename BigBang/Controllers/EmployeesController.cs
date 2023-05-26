using BigBang.Models;
using BigBang.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee emp;
        public EmployeesController(IEmployee emp)
        {
            this.emp = emp;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return emp.GetEmployees();
        }

        [HttpGet("{EmployeeId}")]
        public Employee GetById(int EmployeeId)
        {
            return emp.GetEmployeesById(EmployeeId);
        }

        [HttpPost]
        public Employee PostEmployee(Employee employee)
        {
            return emp.PostEmployee(employee);
        }
        [HttpPut("{EmployeeId}")]
        public Employee PutEmployee(int EmployeeId, Employee employee)
        {
            return emp.PutEmployee(EmployeeId, employee);
        }
        [HttpDelete("{EmployeeId}")]
        public Employee DeleteEmployee(int EmployeeId)
        {
            return emp.DeleteEmployee(EmployeeId);
        }
        [HttpGet("roomcount")]
        public int GetRoomCountByRoomIdAndHotelId(int RoomId, int HotelId)
        {

            return emp.GetRoomCountByRoomIdAndHotelId(RoomId, HotelId);


        }

    }
}
