using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Models
{
    public class Employee : Person
    {
        public Department Department { get; set; }
        public decimal Salary { get; set; }
        public string WorkingTime { get; set; }
    }
}
