using System.Collections.Generic;

namespace filtering
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; }
        public ICollection<Person> Subordinates { get; set; }
    }
}