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
    public class SubjectFileJson : ISubjectData
    {
        public string _filePath;
        public string _folderPath;
        public SubjectFileJson()
        {
            //lấy đường dẫn thư mục tuyệt đối
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FileJson");
            // create file in folder
            _filePath = Path.Combine(_folderPath, "subject.json");
        }

        //Add list student vào file 
        public void AddSubject(Subject _subject)
        {
            // check folder có tồn tại không
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            //ghi thêm data vào file
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(_subject) });
        }

        // Get data từ file
        public List<Subject> GetData()
        {
            var result = new List<Subject>();
            //check file có tồn tại không
            if (File.Exists(_filePath))
            {
                // đọc tất cả data từ file
                var subjectStr = File.ReadAllLines(_filePath);
                // duyệt qua các phần tử trong studentStr
                foreach (var item in subjectStr)
                {
                    // convert các phần tử trong studentStr từ json về model sau đó add vào list
                    result.Add(JsonConvert.DeserializeObject<Subject>(item));
                }
            }
            return result;
        }
    }
}
