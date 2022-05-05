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
    class ScoreHibernate : IScoreFileJson
    {
        public void AddScore(Score score)
        {
            using (ISession session = NHibernateSessions.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(score);
                    transaction.Commit();
                }
            }
        }

        public List<Score> GetData()
        {
            List<Score> scores = new List<Score>();
            using (ISession session = NHibernateSessions.OpenSession())
            {
                scores = session.Query<Score>().ToList();
            }
            return scores;
        }
    }
}
