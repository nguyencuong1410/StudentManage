using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Data
{
    public interface IStudentData
    {
        void AddStudent(Student stu);
        List<Student> GetData();
    }
}
