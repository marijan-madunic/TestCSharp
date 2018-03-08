using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;


namespace TestingCSharp
{         
    public class Report
    {
        public IWebDriver driver;

        public static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string actaulPath = pth.Substring(0, pth.LastIndexOf("bin"));
        public static string projectPath = new Uri(actaulPath).LocalPath;

        public static void takeScreenshot(string filename, IWebDriver driver)
        {
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot screenshot = screenshotDriver.GetScreenshot();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(projectPath + "Reports\\" + filename + ".jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }
    }        
}   
            
            
     

    
