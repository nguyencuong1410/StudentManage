using System;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Interface.Service
{
    public interface ISubjectService
    {
        List<Subject> GetDataSubject();
        Subject InputSubject();
        void ShowListSubject(List<Subject> list_subject);
    }
}
