using System;
using System.IO;
using System.Data.SqlClient;
using Dapper;
using StudentManage.Interface.Data;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Dapper
{
    public class ScoreDapper : IScoreFileJson
    {
        private readonly string _conStr;
        public ScoreDapper(string conStr)
        {
            _conStr = conStr;            
        }

        public void AddScore(Score score)
        {
            using (var connection = new SqlConnection(_conStr))
            {
                connection.Open();
                //var affectedRow = connection.Execute("Insert into tblBangDiem (")
            }
        }

        public List<Score> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
