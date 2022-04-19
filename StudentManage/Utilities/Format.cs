using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Utilities
{
    public class Format
    {
        public void FormatLstStudent()
        {
            var _titleStudent = string.Format("{0,-10} {1,-20} {2,-5} {3,-12} {4,-10} {5,-10}", "ID", "Name", "Gender", "Date", "Class", "Course");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_titleStudent);
            Console.ResetColor();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
        }
        public void FormatLstSubject()
        {
            var _titleSubject = string.Format("{0,-10} {1,-20} {2,-5}", "ID", "Name", "Number of lesson");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_titleSubject);
            Console.ResetColor();
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
        }
    }
}
