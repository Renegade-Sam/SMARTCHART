using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SMARTCHART
{
    public class LogManager
    {
        private readonly string filePath = Path.Combine(Application.StartupPath, "logs.json");

        public void AddLog(string userName, string action, string patientId)
        {
            List<Logs> logs = LoadLogs();
            logs.Add(new Logs(userName, action, patientId));
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            File.WriteAllText(filePath, JsonConvert.SerializeObject(logs, Formatting.Indented));
        }

        public List<Logs> LoadLogs()
        {
            if (!File.Exists(filePath))
            {
                return new List<Logs>();
            }

            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Logs>>(json) ?? new List<Logs>();
        }
    }
}
