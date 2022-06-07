//MSTest framework (Microsoft.VisualStudio.TestTools.UnitTesting)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace E2E
{
    [TestClass]
    [TestCategory("E2E")]
    public class Authentication
    {
        IWebDriver driver = new ChromeDriver(); 
       
        [TestMethod]
        [TestCategory("E2E")]
        public void Login()
        {
            //Get to the main page and click on the login button
            driver.Navigate().GoToUrl("https://localhost:7064/");
            //Code for Maximing the browser window
            driver.Manage().Window.Maximize();

            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            w.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class='ms_btn login_btn']"))).Click();

            //Wait for the new page to open and login in with username and password
            IWebElement Username = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@id='Input_Email']")));
            Username.SendKeys("teacher@test.com");

            var userPasswordField = driver.FindElement(By.XPath("//input[@id='Input_Password']"));
            userPasswordField.SendKeys("Teacher1!");

            var buttonlg = driver.FindElement(By.XPath("//button[@id='login-submit']"));
            buttonlg.Click();

            //Start Roll Call
            //Navigate to the Roll Call page
            IWebElement Rollcallicon = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='rollcallicon']")));
            Rollcallicon.Click();

            //Click on Start Roll call
            var _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='btn btn-secondary btn-lg']"))).Click();
                System.Diagnostics.Debug.Write("Roll Call has started");
            }
            catch (System.LessonnotassignedException)
            {
                IWebElement confirmation = driver.FindElement(By.XPath("//h2"));
                Assert.IsTrue(confirmation.Text.Contains("Students checked in"));
                System.Diagnostics.Debug.Write("There are no lessons assigned to start roll call! ");
            }
            catch (System.Exception e)
            {
                IWebElement confirmation = driver.FindElement(By.XPath("//h2"));
                Assert.IsTrue(confirmation.Text.Contains("Roll call has started!"));
                System.Diagnostics.Debug.Write("Roll call has already started, code is generated");
            }
            //Logout
            IWebElement buttonlgout = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@class='ms_btn reg_btn']")));
            buttonlgout.Click();

            //Wait for the logout page and check if logout message displays to the user
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement message = driver.FindElement(By.XPath("//p"));
            Assert.IsTrue(message.Text.Contains("You are logged out."));

        }

        [TestMethod]
        public void TestPublicAPI()
        {
            //Get to the main page and click on the login button
            driver.Navigate().GoToUrl("https://localhost:7064/");
            //Code for Maximing the browser window
            driver.Manage().Window.Maximize();

            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            w.Until(ExpectedConditions.ElementExists(By.XPath("//a[@class='ms_btn login_btn']"))).Click();

            //Wait for the new page to open and login in with username and password
            IWebElement Username = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@id='Input_Email']")));
            Username.SendKeys("teacher@test.com");

            var userPasswordField = driver.FindElement(By.XPath("//input[@id='Input_Password']"));
            userPasswordField.SendKeys("Teacher1!");

            var buttonlg = driver.FindElement(By.XPath("//button[@id='login-submit']"));
            buttonlg.Click();

            //Navigate to the Roll Call page
            IWebElement Rollcallicon = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[@id='rollcallicon']")));
            Rollcallicon.Click();

            //Find the element containing the quote taken from the public API
            var quoteText = w.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//p[@id='quote']")));
            //Get text out of the element
            var text = quoteText.Text;

            //Check if any data is received
            Assert.IsTrue(text.Length > 1);
        }
    } 
}

    
