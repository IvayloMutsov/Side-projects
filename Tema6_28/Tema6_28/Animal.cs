using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_28
{
    internal class Animal
    {
        public string name;
        public int age;
        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return $"{name},{age}";
        }
    }
}
