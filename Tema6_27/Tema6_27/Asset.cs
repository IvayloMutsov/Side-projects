using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_27
{
    internal class Asset
    {
        public int AssetID { get; set; }
        public string Name { get; set; }
        public decimal InitialCost { get; set; }
        public decimal ResidualValue { get; set; }
        public int UsefulLife { get; set; }
    }
}
