using System;
using System.IO;
using System.Text;

namespace GlobalCapture.AssemblyNode
{
    public static class Log
    {
        private static readonly StringBuilder Content = new StringBuilder();
        private static string CurrentDate => DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");

        public static void AppendError(Exception ex)
        {
            AppendLine(ex.Message);
            AppendLine(ex.StackTrace);
        }

        public static void AppendLine(string line)
        {
            Content.AppendLine(CurrentDate + " " + line);
        }

        public static void SaveToFile(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            using (var sw = File.Exists(path) ? File.AppendText(path) : File.CreateText(path))
            {
                sw.Write(Content.ToString());
            }
            Content.Clear();
        }
    }
}