using System.Reflection;

namespace Tema6_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DepricationCalculator calculator = new DepricationCalculator();
            Console.Write("Enter the number of assets: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Enter information for asset {i}: ");
                string[] info = Console.ReadLine().Split(' ');
                Asset asset = new Asset();
                asset.AssetID = int.Parse(info[0]);
                asset.Name = info[1];
                asset.InitialCost = decimal.Parse(info[2]);
                asset.ResidualValue = decimal.Parse(info[3]);
                asset.UsefulLife = int.Parse(info[4]);
                calculator.AddAsset(asset);
            }
            calculator.DisplayDeprivcationInfo();
            calculator.CalculateDeprication();
        }
    }
}