using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Service
{
    public interface ISubjectRegisterService
    {
        List<SubjectRegister> GetDataRegister();
        SubjectRegister Input();
        void ShowLstRegister(List<SubjectRegister> list_subjectregister);

        void ShowListRegisterDetail(string index, List<SubjectRegister> list_subjectregister);
    }
}
