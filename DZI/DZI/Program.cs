namespace DZI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Stack<Human> stack = new Stack<Human>();
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Your choice [s-student], [w- -worker]: ");
                string choice = Console.ReadLine();
                if (choice == "s")
                {
                    Console.Write("Grade: ");
                    double grade = double.Parse(Console.ReadLine());
                    Human student = new Student(firstName, lastName, age, grade);
                    stack.Push(student);
                }
                else if(choice == "w")
                {
                    Console.Write("Wage: ");
                    double wage = double.Parse(Console.ReadLine());
                    Console.Write("Hours worked: ");
                    int workHours = int.Parse(Console.ReadLine());
                    Human worker = new Worker(firstName, lastName, age, wage, workHours);
                    stack.Push(worker);
                }
                else
                {
                    throw new Exception("Invalid choice!");
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
