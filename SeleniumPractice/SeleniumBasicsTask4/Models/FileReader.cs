namespace SeleniumBasicsTask4.Models
{
    using System;
    using System.IO;

    public static class FileReader
    {
        public static string GetFileContent (string fileName, string directoryName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryName, fileName);
            var fileContent = File.ReadAllText(filePath);
            return fileContent;
        }
    }
}
