using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Repositories
{
    class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSKMAStorage");

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);
        }

        public async Task AddOrUpdateAsync(DBUser obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Login), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<DBUser> GetAsync(string login)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, login);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBUser>(stringObj);
        }

        public async Task<List<DBUser>> GetAllAsync()
        {
            var res = new List<DBUser>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBUser>(stringObj));
            }

            return res;
        }

        public List<DBUser> GetAll()
        {
            var res = new List<DBUser>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<DBUser>(stringObj));
            }

            return res;
        }
    }
}
