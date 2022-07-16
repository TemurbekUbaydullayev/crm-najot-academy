using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role RoleOfCourse { get; set; }
        public decimal Salary { get; set; }
        public string TeacherName { get; set; }
        public string AssistantName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
