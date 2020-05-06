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

            
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[2]/div/form/fieldset/div[8]/input")).SendKeys("Pero");
            driver.FindElement(By.Id("lastname")).SendKeys("Peric");
            driver.FindElement(By.Id("sex-0")).Click();
            driver.FindElement(By.Id("exp-5")).Click();

            driver.FindElement(By.Id("datepicker")).SendKeys("06.04.2020.");
            driver.FindElement(By.Id("profession-0")).Click();
            driver.FindElement(By.Id("profession-1")).Click();
            driver.FindElement(By.Id("photo")).SendKeys(projectPath + "Photo\\image_photo.jpg");

            SelectElement drpContinents = new SelectElement(driver.FindElement(By.Name("continents")));
            drpContinents.SelectByValue("EU");

            SelectElement selenium_commands = new SelectElement(driver.FindElement(By.Id("selenium_commands")));
            selenium_commands.SelectByText("Browser Commands");
            selenium_commands.SelectByText("Switch Commands");


            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/aside[2]/ul/li[18]/a")).Click();
            driver.FindElement(By.Id("datepicker")).SendKeys("03/06/2020");

            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/aside[1]/ul/li[4]/a")).Click();

            
            Actions act = new Actions(driver);
            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement target = driver.FindElement(By.Id("droppable"));
            act.DragAndDrop(source, target).Perform();

            /*
            IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0, -250);");

            Assert.AreEqual("Registration", driver.FindElement(By.CssSelector("h1.entry-title")).Text);
            */

            takeScreenshot("Screenshot", driver);
            test.Log(LogStatus.Info, "Screenshot - " + test.AddScreenCapture(projectPath + "Reports" + "\\" + "Screenshot.jpg"));

            System.Threading.Thread.Sleep(3000);

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