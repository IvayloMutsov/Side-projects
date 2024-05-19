namespace Tema3_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);
            char[] num = s.ToCharArray();
            if (num.Contains('-'))
            {
                Console.WriteLine("Something went wrong!");
                Environment.Exit(1);
            }
            else
            {
                string convert = string.Join(",", num);
                int[] number = convert.Split(',').Select(int.Parse).ToArray();
                int sum = 0;
                List<int> list = new List<int>();
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[0] <= 0)
                    {
                        Console.WriteLine("Something went wrong!");
                        Environment.Exit(1);
                    }
                    else
                    {
                        sum += number[i];
                    }
                }
                for (int i = 1; i <= n; i++)
                {
                    if (sum % i == 0 && i != sum && i != 1)
                    {
                        break;
                    }
                    else
                    {
                        list.Add(i);
                    }
                }
                if (list.Contains(1) && list.Contains(sum))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}