using CRMNAJOTACADEMY.Enums;

namespace CRMNAJOTACADEMY.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
    }
}
