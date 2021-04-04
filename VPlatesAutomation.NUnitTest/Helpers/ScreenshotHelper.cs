using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VPlatesAutomation.NUnitTest
{
    public class ScreenshotHelper
    {
        public static void Capture(IWebDriver Driver)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            var screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile($"{dir}\\{DateTime.UtcNow.Ticks.ToString()}");
        }
    }
}
