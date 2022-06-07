using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;

namespace E2E.Anonymous_tests
{
    [TestClass]
    [TestCategory("E2E")]
    public class AnonymousTests
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        [TestCategory("E2E")]
        public void ConvienceTool()
        {
            //Navigate to the Convience page and wait for loading
            driver.Navigate().GoToUrl("https://localhost:7064/FunandGames");

            //Code for Maximing the browser window
            driver.Manage().Window.Maximize();

            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //Play Marker Colour Picker
            w.Until(ExpectedConditions.ElementExists(By.XPath("//button[@id='pen']"))).Click();

            //Play Coffee Tracker
            var coffeetracker = driver.FindElement(By.XPath("//button[@id='coffee']"));
            coffeetracker.Click();

            //Play Magic 8-Balls
            var magic8ball = driver.FindElement(By.XPath("//input[@id='question']"));
            magic8ball.SendKeys("Should I give my students homework today?");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='spirit']"))).Click();

            //Personal calculator
            var e = driver.FindElement(By.XPath("//table[@id='calculator']"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", e);

            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='9']"))).Click();

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='+']"))).Click();

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait3.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='3']"))).Click();

            WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait4.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='=']"))).Click();

            





        }

    }
}
