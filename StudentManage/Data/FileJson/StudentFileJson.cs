using System;
using System.IO;
using Newtonsoft.Json;
using StudentManage.Models;
using StudentManage.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data
{
    public class StudentFileJson : IStudentData
    {
        public string _filePath;
        public string _folderPath;
        public StudentFileJson()
        {
            //lấy đường dẫn thư mục tuyệt đối
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FileJson");
            // create file in folder
            _filePath = Path.Combine(_folderPath, "student.json");
        }

        //Add list student vào file 
        public void AddStudent(Student stu)
        {
            // check folder có tồn tại không
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            //ghi thêm data vào file
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(stu) });
        }

        // Get data từ file
        public List<Student> GetData()
        {
            var result = new List<Student>();
            //check file có tồn tại không
            if (File.Exists(_filePath))
            {
                // đọc tất cả data từ file
                var studentStr = File.ReadAllLines(_filePath);
                // duyệt qua các phần tử trong studentStr
                foreach ( var item in studentStr)
                {
                   // convert các phần tử trong studentStr từ json về model sau đó add vào list
                    result.Add(JsonConvert.DeserializeObject<Student>(item));
                }
            }
            return result;
        }
    }
}
