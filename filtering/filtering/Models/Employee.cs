using System.Collections.Generic;

namespace filtering.Models
{
    public class Employee
    {
        public Employee()
        {
            Subordinates = new List<Person>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; }
        public ICollection<Person> Subordinates { get; set; }
    }
}