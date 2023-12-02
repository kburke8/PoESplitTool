using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PoESplitTimer
{
    public class LogParser
    {
        private string logFilePath;
        private long lastMaxOffset;
        public event Action<string> OnZoneChanged;

        public LogParser(string path)
        {
            logFilePath = path;
            lastMaxOffset = new FileInfo(logFilePath).Length;
        }

        public void StartMonitoring()
        {
            Task.Run(() => MonitorLogFile());
        }

        private void MonitorLogFile()
        {
            while (true)
            {
                try
                {
                    using (var stream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        if (stream.Length > lastMaxOffset)
                        {
                            stream.Seek(lastMaxOffset, SeekOrigin.Begin);
                            var line = "";
                            while ((line = reader.ReadLine()) != null)
                            {
                                CheckForZoneChange(line);
                            }
                            lastMaxOffset = stream.Position;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (file not found, etc.)
                }
                Task.Delay(100).Wait(); // Delay between checks
            }
        }

        private void CheckForZoneChange(string line)
        {
            // Regex to match zone change log entry. Update this based on the actual log format.
            var match = Regex.Match(line, @"You have entered (.+).");
            if (match.Success)
            {
                var zoneName = match.Groups[1].Value;
                OnZoneChanged?.Invoke(zoneName);
            }
        }

        public void SetLogFilePath(string path)
        {
            logFilePath = path;
            lastMaxOffset = new FileInfo(logFilePath).Length;
        }
    }
}
