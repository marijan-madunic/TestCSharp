using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;


namespace TestingCSharp
{
    [TestFixture]
    class NUnitTest : Report
    {
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form/");

            Console.WriteLine("Opening Chrome");
        }

        [Test]
        public void SiteTest()
        {
            ExtentReports extent = new ExtentReports(projectPath + "Reports\\report.html");
            var test = extent.StartTest("Testing site DemoQA", "Sample Description");
            test.Log(LogStatus.Info, "Testing DemoQA");


            driver.FindElement(By.Id("firstName")).SendKeys("Pero");
            driver.FindElement(By.Id("lastName")).SendKeys("Peric");
            driver.FindElement(By.Id("userEmail")).SendKeys("Pero@example.com");

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[1]/form/div[3]/div[2]/div[1]/label")).Click();

            driver.FindElement(By.Id("userNumber")).SendKeys("0951234567");

            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div[4]/div[3]")).Click();

            driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[1]/form/div[7]/div[2]/div[1]/label")).Click();
            
            driver.FindElement(By.Id("uploadPicture")).SendKeys(projectPath + "Photo\\image_photo.jpg");
            
            //driver.FindElement(By.Id("currentAddress-label")).SendKeys("Address");



            takeScreenshot("Screenshot", driver);
            test.Log(LogStatus.Info, "Screenshot - " + test.AddScreenCapture(projectPath + "Reports" + "\\" + "Screenshot.jpg"));

            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Testing DemoQA");

            extent.EndTest(test);
            extent.Flush();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
            Console.WriteLine("Closing Chrome");
        }
    }
}