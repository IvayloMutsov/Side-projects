namespace Tema5_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list = GetGrade(list);
            Student student1 = new Student(1,"Ivan Ivanov",list);
            Student student2 = new Student(2, "Ivaylo Mutsov",list);
            Student student3 = new Student(3, "Dragana Todorova",list);
            StudentDatabase database = new StudentDatabase();
            database.AddStudent(student1);
            database.AddStudent(student2);
            database.AddStudent(student3);
            foreach (var item in database.students)
            {
                Console.WriteLine(item.ToString());
            }
            database.RemoveStudent(1);
            database.GetStudentInfo(2);
            database.GetStudentInfo(3);
            database.GetStudentAverageScore(2);
            database.GetStudentAverageScore(3);
        }
        public static List<int> GetGrade(List<int> list)
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                list.Add(random.Next(2, 6));
            }
            return list;
        }
    }
}
