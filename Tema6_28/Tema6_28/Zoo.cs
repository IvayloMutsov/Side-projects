using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_28
{
    internal class Zoo
    {
        public string name;
        public string location;
        public List<ZooKeeper> zooKeepers;
        public Zoo(string name,string location,List<ZooKeeper> zooKeepers)
        {
            this.name = name;
            this.location = location;
            this.zooKeepers = new List<ZooKeeper>();
        }
        public void AddZooKeeper(ZooKeeper zooKeeper) { zooKeepers.Add(zooKeeper); }
        public void Info()
        {
            Console.WriteLine($"Zoo: {name} - {location}");
            foreach (var item in zooKeepers)
            {
                item.ToString();
            }
        }
    }
}
