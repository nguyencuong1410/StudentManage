using System;
using Dapper;
using System.Data.SqlClient;
using StudentManage.Interface.Data;
using StudentManage.Interface.Service;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data.Dapper
{
    public class StudentDapper :  IStudentData
    {
        private readonly string _conStr;
        public StudentDapper(string conStr)
        {
            _conStr = conStr;
        }

        public void AddStudent(Student stu)
        {
            using (var connection = new SqlConnection(_conStr))
            {
                connection.Open();
                var affectedRow = connection.Execute("Insert into tblSinhVien(MaSV, HoTen, GioiTinh, NgaySinh, Lop, Khoa) values (@MaSV ,@HoTen,@GioiTinh,@NgaySinh,@Lop,@Khoa)",
                                                       new { MaSV = stu.MaSV, HoTen = stu.HoTen, GioiTinh = stu.GioiTinh, NgaySinh = stu.NgaySinh, Lop = stu.Lop, Khoa = stu.Khoa });
                connection.Close();
            }
        }

        public List<Student> GetData()
        {
            List<Student> listStudent = new List<Student>();
            using (var connection = new SqlConnection(_conStr))
            {
                connection.Open();
                listStudent = connection.Query<Student>("Select * from tblSinhVien").ToList();
                connection.Close();
            }
            return listStudent;
        }
    }
}
