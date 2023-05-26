using System.ComponentModel.DataAnnotations;

namespace BigBang.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
