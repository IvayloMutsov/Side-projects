using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZI
{
    public class Human
    {
        private string firstName;
        private string lastName;
        private int age;
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age} years old.";
        }
    }
}
