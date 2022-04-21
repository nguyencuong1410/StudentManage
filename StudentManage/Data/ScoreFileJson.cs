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
    public class ScoreFileJson : IScoreFileJson
    {
        public string _filePath;
        public string _folderPath;
        public ScoreFileJson()
        {
            _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "FileJson");
            _filePath = Path.Combine(_folderPath, "score.json");
        }
        public void AddScore (Score score)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            File.AppendAllLines(_filePath, new[] { JsonConvert.SerializeObject(score) });
        }
        public List<Score> GetData()
        {
            var result = new List<Score>();
            if (File.Exists(_filePath))
            {
                var scoreStr = File.ReadAllLines(_filePath);
                foreach(var item in scoreStr)
                {
                    result.Add(JsonConvert.DeserializeObject<Score>(item));
                }
            }
            return result;
        }
    }
}
