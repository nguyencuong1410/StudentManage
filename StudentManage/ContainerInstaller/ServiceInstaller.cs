using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using StudentManage.Interface.Service;
using StudentManage.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManage.Interface.Data;
using StudentManage.Data;

namespace StudentManage.ContainerInstaller
{
    // using Castle.MicroKernel.SubSystems.Configuration, sau đó cho class kế thừa IWindsorInstaller
    public class ServiceInstaller : IWindsorInstaller
    {
        // Hàm đăng ký Component vào DI container
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>());
            container.Register(Component.For<ISubjectService>().ImplementedBy<SubjectService>().LifestyleTransient());
            container.Register(Component.For<IStudentData>().ImplementedBy<StudentFileJson>().LifestyleTransient());
            container.Register(Component.For<ISubjectData>().ImplementedBy<SubjectFileJson>().LifestyleTransient());
            container.Register(Component.For<ISubjectRegisterService>().ImplementedBy<SubjectRegisterService>().LifestyleTransient());
            container.Register(Component.For<ISubjectRegisData>().ImplementedBy<SubjectRegisterFile>().LifestyleTransient());
            container.Register(Component.For<IScoreService>().ImplementedBy<ScoreService>().LifestyleTransient());
            container.Register(Component.For<IScoreFileJson>().ImplementedBy<ScoreFileJson>().LifestyleTransient());
        }
    }
}
