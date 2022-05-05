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
            // TODO: Add insert login here
           using (ISession session = NHibernateSessions.OpenSession()) // open sesstion to connect to the database
            {
                using(ITransaction transaction = session.BeginTransaction()) // begin a transaction
                {
                    session.Save(stu); // save stu in session
                    transaction.Commit(); // commit the change to the database
                }
            }
        }

        public List<Student> GetData()
        {
            List<Student> students = new List<Student>();
            using (ISession session = NHibernateSessions.OpenSession())
            {
                students = session.Query<Student>().ToList(); // Query to get all the student
            }
            return students;
        }
    }
}
