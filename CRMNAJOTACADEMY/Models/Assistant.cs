using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Models
{
    public class Assistant : Person
    {
        public Role RoleOfAssistant { get; set; }
        public decimal Salary { get; set; }
    }
}
