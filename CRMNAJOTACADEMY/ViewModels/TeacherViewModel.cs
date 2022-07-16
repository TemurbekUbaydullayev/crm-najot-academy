using CRMNAJOTACADEMY.Enums;
using CRMNAJOTACADEMY.Models;

namespace CRMNAJOTACADEMY.ViewModels
{
    public class TeacherViewModel : Person
    {
        public Role RoleOfTeacher { get; set; }
        public decimal Salary { get; set; }
    }
}
