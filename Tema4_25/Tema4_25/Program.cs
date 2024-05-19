using System.Collections.Immutable;

namespace Tema4_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,double> list = new Dictionary<string, double>();
            double avg = 0;
            int n = int.Parse(Console.ReadLine());
            int m = n;
            double max = 0;
            List<string> students = new List<string>();
            if (n >= 1 && n <= 100) 
            {
                for (int i = 0; i < n; i++)
                {
                    string name = Console.ReadLine();
                    double score = double.Parse(Console.ReadLine());
                    if (max < score)
                    {
                        max = score;
                    }
                    if (score >= 1 && score <= 100)
                    {
                        avg += score;
                        list.Add(name, score);
                    }
                    else if(score == -1)
                    {
                        m--;
                    }
                }
                avg /= n;
            }
            list.ToImmutableSortedDictionary();
            Console.WriteLine($"Number of students: {m}");
            Console.WriteLine($"Average score: {avg:f2}");
            foreach ( KeyValuePair<string,double> item in list)
            {
                if (item.Value == max)
                {
                    students.Add(item.Key);
                }
            }
            Console.WriteLine("Students with heighest greade: "+string.Join(',',students));
        }
    }
}
//try
//{
//    int a = int.Parse(Console.ReadLine());
//    int b = int.Parse(Console.ReadLine());
//    int count = 0;
//    List<int> list = new List<int>();
//    for (int i = Math.Max(a, b); i >= 1; i--)
//    {
//        if (a % i == 0 && b % i == 0)
//        {
//            list.Add(i);
//            count++;
//        }
//    }
//    list.Remove(1);
//    string n = string.Join(" and ", list.ToArray());
//    if (count == 1)
//    {
//        Console.WriteLine($"No ({a} and {b} don't have obsht delitel exept 1)");
//    }
//    else if (count > 1)
//    {
//        Console.WriteLine($"Yes ({a} and {b} have obsht delitel {n})");
//    }
//}
//catch
//{
//    throw new Exception("Something went wrong!");
//}