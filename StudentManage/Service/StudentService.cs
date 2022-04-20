using System;
using Castle.Windsor;
using StudentManage.ContainerInstaller;
using StudentManage.Interface.Service;
using StudentManage.Interface.Data;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public List<Student> GetDataStudent()
        {
            return _studentData.GetData();
        }

        // Input info student
        public Student InputStudent()
        {
            WindsorContainer container = new WindsorContainer();
            container.Install(new ServiceInstaller());
            var _stuService = container.Resolve<IStudentService>();
            List<Student> list_student = _stuService.GetDataStudent();
            Student _student = new Student();
            Console.Write("ID: ");
            // check trùng ID
            string check = Console.ReadLine();
            foreach(var s in list_student)
            {
                if(check == s.MaSV)
                {
                    Console.WriteLine("ID đã tồn tại, mời nhập lại");
                    Console.Write("ID: ");
                    check = Console.ReadLine();
                }
            }
            _student.MaSV = check;
            Console.Write("Name: ");
            _student.HoTen = Console.ReadLine();
            Console.Write("Gender: ");
            _student.GioiTinh = Console.ReadLine();
            Console.Write("Date: ");
            _student.NgaySinh = Console.ReadLine();
            Console.Write("Class: ");
            _student.Lop = Console.ReadLine();
            Console.Write("Course: ");
            _student.Khoa = Console.ReadLine();
            _studentData.AddStudent(_student);
            return _student;
        }

        // Show list student
        public void ShowListStudent(List<Student> list_student)
        {
            foreach (var s in list_student)
            {
                Console.WriteLine("\n{0,-10} {1,-20} {2,-6} {3,-12} {4,-11} {5,-10}", s.MaSV,s.HoTen,s.GioiTinh,s.NgaySinh,s.Lop,s.Khoa);
            }
        }

        // Show student detail
        public void StudentDetail(string index, List<Student> list_student)
        {
            Student result = (from s in list_student where s.MaSV == index select s).FirstOrDefault(); 
            Console.WriteLine("\n{0,-10} {1,-20} {2,-6} {3,-12} {4,-11} {5,-10}", result.MaSV, result.HoTen, result.GioiTinh, result.NgaySinh, result.Lop, result.Khoa);
        }
    }
}
