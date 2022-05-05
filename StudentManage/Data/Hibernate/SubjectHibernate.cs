using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Interface.Data;
using StudentManage.Models;
using NHibernate;
using NHibernate.Cfg;

namespace StudentManage.Data.Hibernate
{
    class SubjectHibernate : ISubjectData
    {
        public void AddSubject(Subject _subject)
        {
            using(ISession session = NHibernateSessions.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(_subject);
                    transaction.Commit();
                }
            }
        }

        public List<Subject> GetData()
        {
            List<Subject> subjects = new List<Subject>();
            using(ISession session = NHibernateSessions.OpenSession())
            {
                subjects = session.Query<Subject>().ToList();
            }
            return subjects;
        }
    }
}
