using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Models
{
    public class Teacher : Person
    {
        public Role RoleOfTeacher { get; set; }
        public decimal Salary { get; set; }
        public string HashPassword { get; set; }
    }
}
