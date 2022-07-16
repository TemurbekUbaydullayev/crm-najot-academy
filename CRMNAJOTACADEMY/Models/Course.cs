using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role RoleOfCourse { get; set; }
        public decimal Salary { get; set; }
        public int TeacherId { get; set; }
        public int AssistantId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
