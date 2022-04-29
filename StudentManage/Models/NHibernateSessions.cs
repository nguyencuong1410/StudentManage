using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Dialect;

namespace StudentManage.Models
{
    class NHibernateSessions
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure(@"D:\Source\C#\StudentManage\StudentManage\Models\hibernate.cfg.xml");
            configuration.AddFile(@"D:\Source\C#\StudentManage\StudentManage\Mapping\Student.hbm.xml");
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
