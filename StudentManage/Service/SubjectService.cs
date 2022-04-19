using System;
using StudentManage.Interface.Data;
using StudentManage.Interface.Service;
using StudentManage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;
        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }
        public List<Subject> GetDataSubject()
        {
            return _subjectData.GetData();
        }
        public Subject InputSubject()
        {
            Subject _subject = new Subject();
            Console.Write("Subject ID: ");
            _subject.MaMH = Console.ReadLine();
            Console.Write("Subject Name: ");
            _subject.TenMH = Console.ReadLine();
            Console.Write("Number of lesson: ");
            _subject.Sotiethoc = Convert.ToInt32(Console.ReadLine());
            _subjectData.AddSubject(_subject);
            return _subject;
        }
        public void ShowListSubject(List<Subject> list_subject)
        {
            foreach (var s in list_subject)
            {
                Console.WriteLine("\n{0,-10} {1,-20} {2,-5}", s.MaMH, s.TenMH, s.Sotiethoc);
            }
        }
    }
}
