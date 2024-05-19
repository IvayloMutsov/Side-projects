namespace Tema2_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many people will you register? ");
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] humans = Console.ReadLine().Split(' ').ToArray();
                Person person = new Person(humans[0], humans[1], int.Parse(humans[2]));
                people[i] = person;
            }
            foreach (var item in people)
            {
                item.GetInfo();
            }
        }
    }
}
