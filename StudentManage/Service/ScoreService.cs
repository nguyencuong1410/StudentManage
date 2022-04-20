using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using StudentManage.Models;
using StudentManage.ContainerInstaller;
using StudentManage.Interface.Service;
using StudentManage.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service
{
    public class ScoreService 
    {
        // INPUT SCORE
        public Score InputScore()
        {
            Score score = new Score();
            Console.Write("Điểm TP: ");
            score.DiemTP = float.Parse(Console.ReadLine());
            Console.Write("Điểm QT: ");
            score.DiemQT = float.Parse(Console.ReadLine());
            score.DiemTong = (score.DiemQT + score.DiemTP) / 2;
            return score;
        }

        // sum function
        //public void Sum(Score score)
        //{
        //    score.DiemTong = (score.DiemQT + score.DiemTP) / 2;
        //}

        // SHOW LIST SCORE
        //public void ShowLstScore(List<Score> listScore)
        //{
        //    Console.Write("Nhập ID Student: ");
        //    string check = Console.ReadLine();
        //    foreach(var s in listScore)
        //    {
        //        if(check == s.)
        //    }
        //}
    }
}
