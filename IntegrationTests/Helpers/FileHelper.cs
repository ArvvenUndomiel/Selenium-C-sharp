using System;
using System.IO;

namespace AutomationCourseMockingHomework.Helpers
{
    public static class FileHelper
    {
        public static string GetFileContent(string fileName, string directoryName)
        {
            // option1 = F:\Documents\Software University\QA Automation\API and Integration\AutomationCourseMockingHomework
            // option2 = F:\Documents\Software University\QA Automation\API and Integration\AutomationCourseMockingHomework\bin\Debug\netcoreapp2.1\data
            //var option1 = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            // In order for this path to work, you need to 
            // Right click on the file -> Properties-> Copy To Output directory 
            // Set to Copy Always
            var option2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryName, fileName);
            var fileContent = File.ReadAllText(option2);
            return fileContent;
        }
    }
}
