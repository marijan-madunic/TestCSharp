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

            driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='genterWrapper']/div[@class='col-md-9 col-sm-12']/div[@class='custom-control custom-radio custom-control-inline'][1]/label[@class='custom-control-label']")).Click();
            
            driver.FindElement(By.Id("userNumber")).SendKeys("0951234567");

            driver.FindElement(By.Id("dateOfBirthInput")).Clear();
            driver.FindElement(By.Id("dateOfBirthInput")).SendKeys("06 Jun 2020");



            //driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='subjectsWrapper']/div[@class='col-md-9 col-sm-12']/div[@id='subjectsContainer']/div[@class='subjects-auto-complete__control css-yk16xz-control']/div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3']")).Click();


            //driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='subjectsWrapper']/div[@class='col-md-9 col-sm-12']/div[@id='subjectsContainer']/div[@class='subjects-auto-complete__control subjects-auto-complete__control--is-focused subjects-auto-complete__control--menu-is-open css-1pahdxg-control']/div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3']")).SendKeys("English");


            //driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='subjectsWrapper']/div[@class='col-md-9 col-sm-12']/div[@id='subjectsContainer']/div[@class='subjects-auto-complete__control subjects-auto-complete__control--is-focused subjects-auto-complete__control--menu-is-open css-1pahdxg-control']/div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3']")).Click();

            //driver.FindElement(By.ClassName("subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi css-1hwfws3")).Click();
            //SelectElement se = new SelectElement(driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='subjectsWrapper']/div[@class='col-md-9 col-sm-12']/div[@id='subjectsContainer']/div[@class='subjects-auto-complete__control subjects-auto-complete__control--is-focused css-1pahdxg-control']/div[@class='subjects-auto-complete__value-container subjects-auto-complete__value-container--is-multi subjects-auto-complete__value-container--has-value css-1hwfws3']")));
            //se.SelectByValue("English");

            // driver.FindElement(By.XPath("/html/body/div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']/div[@class='col-12 mt-4 col-md-6']/div[@class='practice-form-wrapper']/form[@id='userForm']/div[@id='hobbiesWrapper']/div[@class='col-md-9 col-sm-12']/div[@class='custom-control custom-checkbox custom-control-inline'][3]/label[@class='custom-control-label']")).Click();
            

            driver.FindElement(By.Id("uploadPicture")).SendKeys(projectPath + "Photo\\image_photo.jpg");

            driver.FindElement(By.Id("currentAddress")).SendKeys("Address");



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