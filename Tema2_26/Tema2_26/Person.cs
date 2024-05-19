using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_26
{
    internal class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public Person(string firstName, string lastName,int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        public void GetInfo()
        {
            Console.WriteLine($"{firstName} {lastName} is {age} years old.");
        }
    }
}
