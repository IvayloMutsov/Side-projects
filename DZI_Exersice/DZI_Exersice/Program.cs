using System.Collections.Generic;

namespace DZI_Exersice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Stack<string> stack = new Stack<string>();
            Console.Write("Enter the number of floors: ");
            int floors = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of apartments: ");
            int apartments = int.Parse(Console.ReadLine());
            for (int i = 1; i <= floors; i++)
            {
                List<string> list = new List<string>();
                if (i == floors)
                {
                    for (int j = 0; j < apartments; j++)
                    {
                        string room = $"L{i}{j}";
                        list.Add(room);
                    }
                    string floor = $"Floor {i} -> {string.Join(" ", list)}";
                    stack.Push(floor);
                }
                else if (i % 2 == 0)
                {
                    for (int j = 0; j < apartments; j++)
                    {
                        string room = $"O{i}{j}";
                        list.Add(room);
                    }
                    string floor = $"Floor {i} -> {string.Join(" ", list)}";
                    stack.Push(floor);
                }
                else
                {
                    for (int j = 0; j < apartments; j++)
                    {
                        string room = $"A{i}{j}";
                        list.Add(room);
                    }
                    string floor = $"Floor {i} -> {string.Join(" ", list)}";
                    stack.Push(floor);
                }
            }
            Console.WriteLine("The distribution is as following: ");
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}