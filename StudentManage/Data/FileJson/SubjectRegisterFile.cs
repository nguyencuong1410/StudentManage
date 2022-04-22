using System;
using Newtonsoft.Json;
using System.IO;
using StudentManage.Models;
using StudentManage.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManage.Data
{
    public class SubjectRegisterFile : ISubjectRegisData
    {
        public string _filePath;
        public string _folderPath;
        public SubjectRegisterFile()
        {
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FileJson");
            _filePath = Path.Combine(_folderPath, "subjectregister.json");
        }
        public void AddRegister(SubjectRegister subjectRegister)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(subjectRegister) });
        }
        public List<SubjectRegister> GetData()
        {
            var result = new List<SubjectRegister>();
            //check file có tồn tại không
            if (File.Exists(_filePath))
            {
                // đọc tất cả data từ file
                var subjectRegis = File.ReadAllLines(_filePath);
                // duyệt qua các phần tử trong studentRegis
                foreach (var item in subjectRegis)
                {
                    // convert các phần tử trong studentRegis từ json về model sau đó add vào list
                    result.Add(JsonConvert.DeserializeObject<SubjectRegister>(item));
                }
            }
            return result;
        }
    }
}
