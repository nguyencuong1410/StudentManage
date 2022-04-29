using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Models
{
    public class Student
    {
        public virtual string MaSV { get; set; }
        public virtual string HoTen { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual string NgaySinh { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }
    }

}
