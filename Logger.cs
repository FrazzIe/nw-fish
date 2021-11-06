using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nw_fish
{
    public static class Logger
    {
        private static string directory = Path.Combine(Environment.CurrentDirectory, "logs");
        private static string file = $"[{DateTime.Now:G}] log.txt".Replace('/', '-').Replace(':', '-');

        public static void Log(string category, string message)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (StreamWriter writer = File.AppendText(Path.Combine(directory, file)))
            {
                writer.WriteLine($"[{DateTime.Now:G}] {category}: {message}");
            }
        }
    }
}
