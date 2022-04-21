using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using StudentManage.Models;
using StudentManage.ContainerInstaller;
using StudentManage.Interface.Service;
using StudentManage.Interface.Data;
using StudentManage.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreFileJson _scoreFileJson;
        public ScoreService(IScoreFileJson scoreFileJson)
        {
            _scoreFileJson = scoreFileJson;
        }
        public List<Score> GetDataScore()
        {
            return _scoreFileJson.GetData();
        }


        // INPUT SCORE
        public Score InputScore()
        {
            WindsorContainer container = new WindsorContainer();
            container.Install(new ServiceInstaller());
            var _subjectRegister = container.Resolve<ISubjectRegisterService>();
            List<SubjectRegister> listSubjectRegister = _subjectRegister.GetDataRegister();
            Score score = new Score();
            Console.Write("ID Student cần nhập điểm: ");
            string id = Console.ReadLine();
            while (listSubjectRegister.Find(x => x.MaSV == id) == null)
            {
                Console.WriteLine("Không có data!");
                Console.WriteLine("Nhập lại ID Student: ");
                id = Console.ReadLine();
            }
            _subjectRegister.ShowListRegisterDetail(id, listSubjectRegister);
            score.MaSV = id;
            Console.Write("ID Subject cần nhập điểm: ");
            score.MaMH = Console.ReadLine();
            Console.Write("Điểm TP: ");
            score.DiemTP = float.Parse(Console.ReadLine());
            Console.Write("Điểm QT: ");
            score.DiemQT = float.Parse(Console.ReadLine());
            score.DiemTong = (score.DiemTP + score.DiemQT) / 2;
            if (score.DiemTong >= 4)
            {
                score.DanhGia = "Đỗ";
            }
            else
            {
                score.DanhGia = "Trượt";
            }
            _scoreFileJson.AddScore(score);
            return score;
        }

        // SHOW LIST SCORE
        public void ShowLstScore(string index, List<Score> listScore)
        {
            Score result = (from s in listScore where s.MaSV == index select s).FirstOrDefault();
            Format _format = new Format();
            _format.FormatLstScore();
            var formatStr = string.Format("{0,-10} {1,-10} {2,-8} {3,-8} {4,-8} {5,-5}", result.MaSV, result.MaMH, result.DiemTP, result.DiemQT, result.DiemTong, result.DanhGia);
            if (result.DanhGia == "Trượt")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + formatStr);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\n" + formatStr);
            }

        }
    }
}
