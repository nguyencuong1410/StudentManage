using System;
using StudentManage.Utilities;
using StudentManage.Service;
using StudentManage.Models;
using StudentManage.Data;
using StudentManage.Interface.Service;
using StudentManage.Interface.Data;
using StudentManage.ContainerInstaller;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            #region WindsorContainer
            Format _format = new Format();
            WindsorContainer container = new WindsorContainer();
            //use method install ServiceInstaller to container
            container.Install(new ServiceInstaller());
            //muốn dùng các method của Interface thì ta gọi container.Resolve<Interface>()
            // Resolve an object của IStudentService
            var _istudentService = container.Resolve<IStudentService>();
            var _isubjectService = container.Resolve<ISubjectService>();
            var _isubjectRegister = container.Resolve<ISubjectRegisterService>();
            var _iscoreService = container.Resolve<IScoreService>();
            // clean up
            container.Dispose();
            List<Student> listStudent = _istudentService.GetDataStudent();
            List<Subject> listSubject = _isubjectService.GetDataSubject();
            List<SubjectRegister> listRegister = _isubjectRegister.GetDataRegister();
            List<Score> listScore = _iscoreService.GetDataScore();
            #endregion

            // Menu chương trình
            #region MENU
            while (true)
            {
            menu:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("|                CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN            |");
                Console.WriteLine("+---------------------------  MENU  -----------------------+");
                Console.ResetColor();
                Console.WriteLine("|                      Chọn chức năng:                     |");
                Console.WriteLine("|                  1: Nhập thông tin sinh viên             |");
                Console.WriteLine("|                  2: Danh sách sinh viên                  |");
                Console.WriteLine("|                  3: Xem chi tiết sinh viên               |");
                Console.WriteLine("|                  4: Đăng ký môn học                      |");
                Console.WriteLine("|                  5: Xem số môn học đăng ký               |");
                Console.WriteLine("|                  6: Nhập điểm sinh viên                  |");
                Console.WriteLine("|                  7: Xem điểm sinh viên(đỗ/trượt)         |");
                Console.WriteLine("|                  8: Nhập thông tin môn học               |");
                Console.WriteLine("|                  9: Danh sách môn học                    |");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("+----------------------------------------------------------+");
                Console.ResetColor();
                Console.Write("Chọn chức năng: ");
                int Choose = Convert.ToInt32(Console.ReadLine());

                switch (Choose)
                {
                    case 1:
                        listStudent.Add(_istudentService.InputStudent());
                        Console.WriteLine("Bạn có muốn tiếp tục(y/n) ?");
                        string pick = Console.ReadLine();
                        if (pick == "y")
                        {
                            goto case 1;
                        }
                        else
                        {
                            Console.Clear();
                            goto menu;
                        }
                    case 2:
                        _format.FormatLstStudent();
                        _istudentService.ShowListStudent(listStudent);
                        break;
                    case 3:
                        Console.Write("Nhập ID: ");
                        string index = Console.ReadLine();
                        while(listStudent.Find(x => x.MaSV == index) == null)
                        {
                            Console.WriteLine("Không có sinh viên này!");
                            Console.WriteLine("Nhập lại ID: ");
                            index = Console.ReadLine();
                        }
                        _format.FormatLstStudent();
                        _istudentService.StudentDetail(index, listStudent);
                        break;
                    case 4:
                        listRegister.Add(_isubjectRegister.Input());
                        break;
                    case 5:
                        Console.Write("Nhập ID Student: ");
                        string index1 = Console.ReadLine();
                        while(listRegister.Find(x => x.MaSV == index1) == null)
                        {
                            Console.WriteLine("Không có data!");
                            Console.WriteLine("Nhập lại ID Student: ");
                            index = Console.ReadLine();
                        }
                        _format.FormatLstRegister();
                        _isubjectRegister.ShowListRegisterDetail(index1, listRegister);
                        break;
                    case 6:
                        listScore.Add(_iscoreService.InputScore());
                        Console.WriteLine("Bạn có muốn tiếp tục(y/n) ?");
                        string pick2 = Console.ReadLine();
                        if (pick2 == "y")
                        {
                            goto case 6;
                        }
                        else
                        {
                            Console.Clear();
                            goto menu;
                        }
                    case 7:
                        Console.Write("Nhập ID Student: ");
                        string check2 = Console.ReadLine();
                        while(listScore.Find(x => x.MaSV == check2) == null)
                        {
                            Console.WriteLine("ID này không tồn tại!");
                            Console.WriteLine("Nhập lại ID: ");
                            check2 = Console.ReadLine();
                        }
                        _iscoreService.ShowLstScore(check2, listScore);
                        break;
                    case 8:
                        listSubject.Add(_isubjectService.InputSubject());
                        Console.WriteLine("Bạn có muốn tiếp tục(y/n) ?");
                        string pick1 = Console.ReadLine();
                        if (pick1 == "y")
                        {
                            goto case 8;
                        }
                        else
                        {
                            Console.Clear();
                            goto menu;
                        }
                    case 9:
                        _format.FormatLstSubject();
                        _isubjectService.ShowListSubject(listSubject);
                        break;
                    default:
                        Console.WriteLine("Không có chức năng này!");
                        Console.WriteLine("Hãy chọn các chức năng có trong menu");
                        break;
                }
            }
            #endregion
        }
    }
}
