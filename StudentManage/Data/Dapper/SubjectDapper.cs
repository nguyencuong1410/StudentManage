using System;
using Dapper;
using System.Data.SqlClient;
using StudentManage.Models;
using StudentManage.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Dapper
{
    public class SubjectDapper : ISubjectData
    {
        private readonly string _conStr;
        public SubjectDapper(string conStr)
        {
            _conStr = conStr;
        } 
        public void AddSubject(Subject _subject)
        {
            using (var connection = new SqlConnection(_conStr))
            {
                connection.Open();
                var affectedRow = connection.Execute("Insert into tblMonHoc (MaMH,TenMH,Sotiethoc) values (@MaMH,@TenMH,@Sotiethoc)",
                                                        new { MaMH = _subject.MaMH, TenMH = _subject.TenMH, Sotiethoc = _subject.Sotiethoc });
                connection.Close();
            }
        }

        public List<Subject> GetData()
        {
            List<Subject> listSubject = new List<Subject>();
            using( var connection = new SqlConnection(_conStr))
            {
                connection.Open();
                listSubject = connection.Query<Subject>("Select * from tblMonHoc").ToList();
                connection.Close();
            }
            return listSubject;
        }
    }
}
