using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_28
{
    internal class ZooKeeper : Person
    {
        public ZooKeeper(string name, int age, Animal favouriteAnimal, string specialization) : base(name,age,favouriteAnimal,specialization)
        {
            this.name = name;
            this.age = age;
            this.favouriteAnimal = favouriteAnimal;
            this.spcialization = specialization;
        }
        public override string ToString()
        {
            return $"{name},{age},{spcialization},{favouriteAnimal.ToString()}";
        }
    }
}
