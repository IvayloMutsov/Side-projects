using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5_28
{
    internal class Student
    {
        public int student_id;
        public string name;
        public List<int> scores;
        public Student(int student_id,string name,List<int> scores)
        {
            this.student_id = student_id;
            this.name = name;
            this.scores = scores;
        }
    }
}
