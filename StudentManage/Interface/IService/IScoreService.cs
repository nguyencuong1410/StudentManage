using System;
using System.Collections.Generic;
using StudentManage.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Service
{
    public interface IScoreService
    {
        List<Score> GetDataScore();
        Score InputScore();
        void ShowLstScore(string index, List<Score> listScore);
    }
}
