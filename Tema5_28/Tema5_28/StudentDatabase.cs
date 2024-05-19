using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_28
{
    internal class StudentDatabase
    {
        public List<Student> students;
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void RemoveStudent(int student_id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].student_id == student_id)
                {
                    students.Remove(students[i]);
                }
            }
        }
        public void GetStudentInfo(int student_id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].student_id == student_id)
                {
                    Console.WriteLine($"{students[i].student_id}. {students[i].name}: {string.Join(',', students[i].scores)}");
                }
            }
        }
        public void GetStudentAverageScore(int student_id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].student_id == student_id)
                {
                    int avg = 0;
                    for(int j = 0; j < students[i].scores.Count; j++)
                    {
                        avg += students[i].scores[j];
                    }
                    Console.WriteLine(students[i] + ": " + avg);
                }
            }
        }
    }
}
