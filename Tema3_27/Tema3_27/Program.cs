namespace Tema3_27//And 28 maybe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> list = new Dictionary<string, string>();
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Add":
                        list.Add(command[1], command[2]);
                        break;
                    case "Remove":
                        string r = command[1];
                        if (list.ContainsKey(r))
                        {
                            list.Remove(r);
                        }
                        break;
                    case "Search":
                        string name = command[1];
                            if (list.ContainsKey(name))
                            {
                                Console.WriteLine($"The phone number of {name} is: {list.GetValueOrDefault(name)}");
                            } 
                        break;
                    case "Update":
                        if (list.ContainsKey(command[1]))
                        {
                            string a = list.GetValueOrDefault(command[1]);
                            a = command[2];
                            list[command[1]] = a;
                        }
                        break;
                    case "Print":
                        Console.WriteLine("Name | Phone Number");
                        foreach (KeyValuePair<string, string> item in list)
                        {
                            Console.WriteLine($"{item.Key} | {item.Value}");
                        }
                        break;
                }
                command = Console.ReadLine().Split(' ');
            }
        }
    }
}
//    ZAD 27
//static void Main(string[] args)
//{
//    int n = int.Parse(Console.ReadLine());
//    List<int> list = new List<int>();
//    for (int i = 0; i < n; i++)
//    {
//        int m = int.Parse(Console.ReadLine());
//        if (m < 0 || m > 100)
//        {
//            throw new Exception("Invalid points!");
//        }
//        list.Add(m);
//    }
//    Grade(list);
//}
//static void Grade(List<int> list)
//{
//    foreach (var item in list)
//    {
//        if (item < 40)
//        {
//            Console.WriteLine("Neuspeshen");
//        }
//        else if (item >= 40 && item <= 59)
//        {
//            Console.WriteLine("Sreden");
//        }
//        else if (item >= 60 && item <= 79)
//        {
//            Console.WriteLine("Dobar");
//        }
//        else if (item >= 80 && item <= 89)
//        {
//            Console.WriteLine("Mnogo Dobar");
//        }
//        else if (item >= 90)
//        {
//            Console.WriteLine("Otlichen");
//        }
//    }
//}