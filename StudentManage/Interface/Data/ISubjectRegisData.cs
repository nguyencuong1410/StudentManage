using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Data
{
    public interface ISubjectRegisData
    {
        void AddRegister(SubjectRegister subjectRegister);
        List<SubjectRegister> GetData();
    }
}
