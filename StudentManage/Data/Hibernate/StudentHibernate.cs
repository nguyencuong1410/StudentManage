using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using StudentManage.Interface.Data;
using StudentManage.Models;

namespace StudentManage.Data.Hibernate
{
    class StudentHibernate : IStudentData
    {
        public void AddStudent(Student stu)
        {
           using (ISession session = NHibernateSessions.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(stu);
                    transaction.Commit();
                }
            }
        }

        public List<Student> GetData()
        {
            List<Student> students = new List<Student>();
            using (ISession session = NHibernateSessions.OpenSession())
            {
                students = session.Query<Student>().ToList();
            }
            return students;
        }
    }
}
