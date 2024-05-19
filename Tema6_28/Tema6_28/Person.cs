using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_28
{
    internal class Person
    {
        public string name;
        public int age;
        public Animal favouriteAnimal;
        public string spcialization;
        public Person(string name, int age, Animal favouriteAnimal, string specialization)
        {
            this.name = name;
            this.age = age;
            this.favouriteAnimal = favouriteAnimal;
            this.spcialization = specialization;
        }
    }
}
