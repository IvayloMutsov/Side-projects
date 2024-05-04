using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZI
{
    public class Worker : Human
    {
        private string firstName;
        private string lastName;
        private int age;
        private double wage;
        private int workHours;
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Wage{ get; set; }
        public int WorkHours { get; set; }
        public Worker(string firstName, string lastName, int age, double wage, int workHours):base(firstName, lastName,age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Wage = wage;
            WorkHours = workHours;
        }
        public double Salary()
        {
            return Wage * WorkHours;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age} years old, salary: ${Salary():f2}.";
        }
    }
}
