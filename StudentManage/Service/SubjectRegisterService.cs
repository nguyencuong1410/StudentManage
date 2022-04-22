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
        
        #region REGISTER SUBJECT
        public SubjectRegister Input ()
        {
            WindsorContainer container = new WindsorContainer();
            container.Install(new ServiceInstaller());
            var _stuService = container.Resolve<IStudentService>();
            var _stuSubject = container.Resolve<ISubjectService>();
            List<Student> listStudent = _stuService.GetDataStudent();
            List<Subject> listSubject = _stuSubject.GetDataSubject();
            SubjectRegister _subjectRegister = new SubjectRegister();
            //DS sinh viên
            Console.WriteLine("\n---Danh sách sinh viên---");
            _stuService.ShowListStudent(listStudent);
            //DS môn học
            Console.WriteLine("\n---Danh sách môn học---");
            _stuSubject.ShowListSubject(listSubject);
            // check ID
            Console.Write("Nhập ID sinh viên: ");
            string check = Console.ReadLine();
            while(!listStudent.Select(s => s.MaSV).Contains(check))
            {
                Console.WriteLine("Không có ID Student này!");
                Console.Write("Nhập lại ID: ");
                check = Console.ReadLine();
            }
            _subjectRegister.MaSV = check;
            Console.Write("Nhập ID môn học muốn đăng ký: ");
            _subjectRegister.MaMH = Console.ReadLine();
            Console.Write("Nhập tên môn học: ");
            _subjectRegister.TenMH = Console.ReadLine();
            _subjectRegisData.AddRegister(_subjectRegister);
            return _subjectRegister;
        }
        #endregion
        public void ShowLstRegister(List<SubjectRegister> listSubjectregister)
        {
            foreach(var s in listSubjectregister)
            {
                Console.WriteLine("\n{0,-10}  {1,-10}  {2,-20}", s.MaSV, s.MaMH, s.TenMH);
            }
        }

        #region SHOW LIST SUBJECT FOLLOW ID STUDENT
        public void ShowListRegisterDetail(string index, List<SubjectRegister> listSubjectregister)
        {
            var result = from s in listSubjectregister where s.MaSV == index select s;
            foreach(var x in result)
            {
                Console.WriteLine("\n{0,-10} {1,-10} {2,-20}", x.MaSV, x.MaMH, x.TenMH);
            }
            
        }
        #endregion
    }
}
