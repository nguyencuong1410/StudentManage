using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Service
{
    interface IStudentService
    {
        List<Student> GetDataStudent();
        Student InputStudent();
        void ShowListStudent(List<Student> list_student);
        void StudentDetail(string index, List<Student> list_student);
    }
}
