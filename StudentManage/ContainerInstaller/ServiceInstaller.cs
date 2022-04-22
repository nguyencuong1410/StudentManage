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
            // Chúng ta phải Register để Container biết phụ thuộc lớp nào để khởi tạo
            // dùng Register IStudentService tới vùng chứa của Container và ánh xạ nó tới StudentService 
            // Nếu muốn sử dụng các method của StudentService thì ta phải dùng method Register trước sau đó dùng method Resolve để sử dụng
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
