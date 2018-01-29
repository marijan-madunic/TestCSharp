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


namespace TestingCSharp
{
    class NUnitTest
    {
        IWebDriver driver;
        

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://demoqa.com");
        }

        [Test]
        public void SiteTest()
        {

            driver.FindElement(By.Id("menu-item-374")).Click();

            driver.FindElement(By.Id("name_3_firstname")).SendKeys("Anon");
            driver.FindElement(By.Id("name_3_lastname")).SendKeys("Ymous");
            driver.FindElement(By.CssSelector("input[value='divorced']")).Click();
            driver.FindElement(By.CssSelector("input[value='dance']")).Click();

            driver.FindElement(By.Id("dropdown_7")).SendKeys("Croatia");

            driver.FindElement(By.Id("mm_date_8")).SendKeys("6");
            driver.FindElement(By.Id("dd_date_8")).SendKeys("6");
            driver.FindElement(By.Id("yy_date_8")).SendKeys("1996");

            driver.FindElement(By.Id("phone_9")).SendKeys("00385951234567");
            driver.FindElement(By.Id("username")).SendKeys("Anon");
            driver.FindElement(By.Id("email_1")).SendKeys("anon@example.com");
            driver.FindElement(By.Id("profile_pic_10")).SendKeys(@"C:\Users\Osijek\documents\visual studio 2013\Projects\TestingCSharp\TestingCSharp\Photo\");
            driver.FindElement(By.Id("description")).SendKeys("Hi, I am Anon");
            driver.FindElement(By.Id("password_2")).SendKeys("A3n201n3.6h5g");
            driver.FindElement(By.Id("confirm_password_password_2")).SendKeys("A3n201n3.6h5g");

            IJavaScriptExecutor jse = driver as IJavaScriptExecutor;
            jse.ExecuteScript("window.scrollBy(0, -250);");

            Assert.AreEqual("Registration", driver.FindElement(By.CssSelector("h1.entry-title")).Text);

            driver.FindElement(By.Id("menu-item-38")).Click();

            driver.FindElement(By.Id("menu-item-141")).Click();
            
            Actions act = new Actions(driver);
            IWebElement source = driver.FindElement(By.Id("draggableview"));
            IWebElement target = driver.FindElement(By.Id("droppableview"));
            act.DragAndDrop(source, target).Perform();
            
            driver.FindElement(By.Id("menu-item-146")).Click();

            driver.FindElement(By.Id("datepicker1")).SendKeys("February 12, 2018");

            Assert.AreEqual("Datepicker", driver.FindElement(By.CssSelector("h1.entry-title")).Text);

            System.Threading.Thread.Sleep(3000);
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

    }
}
