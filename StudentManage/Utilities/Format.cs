using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Utilities
{
    public class Format
    {
        #region Format List Student
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
        #endregion

        #region Format List Subject
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
        #endregion

        #region Format List Subject Register
        public void FormatLstRegister()
        {
            var _titleSubjectRegister = string.Format("{0,-10}|{1,-10}|{2,-20}", "ID Student", "ID Subject", "Name of Subject");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_titleSubjectRegister);
            Console.ResetColor();
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
        }
        #endregion
        public void FormatLstScore()
        {
            var _titleScore = string.Format("{0,-10}|{1,-10}|{2,-8}|{3,-5}|{4,-5}|{5,-10}", "ID Student", "ID Subject","Điểm TP","Điểm QT","Điểm Tổng","Đánh giá");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_titleScore);
            Console.ResetColor();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
        }
    }
}
