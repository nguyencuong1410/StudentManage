using System;
using System.Collections.Generic;
using StudentManage.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Data
{
    public interface IScoreFileJson
    {
        void AddScore(Score score);
        List<Score> GetData();
    }
}
