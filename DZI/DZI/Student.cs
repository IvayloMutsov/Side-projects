using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZI
{
    public class Student : Human
    {
        private string firstName;
        private string lastName;
        private int age;
        private double grade;
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public Student(string firstName, string lastName, int age, double grade) : base(firstName, lastName, age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age} years old, grade: {Grade}.";
        }
    }
}
