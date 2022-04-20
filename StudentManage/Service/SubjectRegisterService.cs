using System;
using Castle.Windsor;
using StudentManage.ContainerInstaller;
using StudentManage.Models;
using StudentManage.Interface.Service;
using StudentManage.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service
{
    public class SubjectRegisterService : ISubjectRegisterService
    {
        private readonly ISubjectRegisData _subjectRegisData;
        public SubjectRegisterService(ISubjectRegisData subjectRegisData)
        {
            _subjectRegisData = subjectRegisData;
        }
        public List<SubjectRegister> GetDataRegister()
        {
            return _subjectRegisData.GetData();
        }
        // Register Subject
        public SubjectRegister Input ()
        {
            WindsorContainer container = new WindsorContainer();
            container.Install(new ServiceInstaller());
            var _stuService = container.Resolve<IStudentService>();
            var _stuSubject = container.Resolve<ISubjectService>();
            List<Student> list_student = _stuService.GetDataStudent();
            List<Subject> list_subject = _stuSubject.GetDataSubject();
            SubjectRegister _subjectRegister = new SubjectRegister();
            Console.Write("Hiện danh sách sinh viên(y/n)? ");
            string test = Console.ReadLine();
            if(test =="y" || test == "Y")
            {
                _stuService.ShowListStudent(list_student);
                Console.WriteLine("Hiện danh sách môn học(y/n)?");
                string test1 = Console.ReadLine();
                if (test1 == "y" || test1 == "Y")
                {
                    _stuSubject.ShowListSubject(list_subject);
                    Console.Write("Nhập ID sinh viên: ");
                    _subjectRegister.MaSV = Console.ReadLine();
                    Console.Write("Nhập ID môn học muốn đăng ký: ");
                    _subjectRegister.MaMH = Console.ReadLine();
                    Console.Write("Nhập tên môn học: ");
                    _subjectRegister.TenMH = Console.ReadLine();
                    _subjectRegisData.AddRegister(_subjectRegister);
                }
            }
            return _subjectRegister;
        }
        public void ShowLstRegister(List<SubjectRegister> list_subjectregister)
        {
            foreach(var s in list_subjectregister)
            {
                Console.WriteLine("\n{0,-10}  {1,-10}  {2,-20}", s.MaSV, s.MaMH, s.TenMH);
            }
        }

        public void ShowListRegisterDetail(string index, List<SubjectRegister> list_subjectregister)
        {
            var result = (from s in list_subjectregister where s.MaSV == index select s).FirstOrDefault();
            Console.WriteLine("\n{0,-10} {1,-10} {2,-20}", result.MaSV, result.MaMH, result.TenMH);
        }
    }
}
