using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6_27
{
    internal class DepricationCalculator
    {
        private List<Asset> assets;
        public DepricationCalculator()
        {
            assets = new List<Asset>();
        }
        public void AddAsset(Asset asset)
        {
            assets.Add(asset);
        }
        public void CalculateDeprication()
        {
            foreach (var item in assets)
            {
               decimal deprication = (item.InitialCost - item.ResidualValue) / item.UsefulLife;
               Console.WriteLine($"Deprication: {deprication:f2} per year");
            }
        }
        public void DisplayDeprivcationInfo()
        {
            foreach (var item in assets)
            {
                decimal deprication = (item.InitialCost - item.ResidualValue) / item.UsefulLife;
                decimal deprication2 = deprication;
                Console.WriteLine($"AssetID: {item.AssetID},Name: {item.Name}, Initial Cost: {item.InitialCost:f2},Residual Value: {item.ResidualValue:f2},Useful Life: {item.UsefulLife}");
                for (int i = 1; i <= item.UsefulLife; i++)
                {
                    Console.WriteLine($"Year {i}: Accumulated Deprication: {deprication:f2}");
                    deprication += deprication2;
                }
            }
        }
    }
}
