using System;
using E1CSharpAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq.Expressions;
using OpenQA.Selenium.Support.UI;

namespace Exercise1CSharpA
{
    [TestClass]
    public class Tests
    {
        private IWebDriver driver; 
        [TestInitialize]
        public void Setup()
        { 
            var MySetUp = new SetUp();
            driver = MySetUp.SetUpMethod();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void myUnitTest()
        {
            try
            {
                var FBTest = new TestInteraction();
                // Go to facebook.com
                FBTest.GoToFacebookPage(driver);
                // Verify text is displayed using Custom Assert to print successful validation message
                FBTest.VerifyTextDisplayed(driver);
                // Fill information and log the action on console
                FBTest.FillInformation(driver);
                // Exception handler to catch the exception and display a customized message for elements that do not exist
                FBTest.WaitForElementDoesNotExist(driver);
                closeAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        [TestCleanup]
        public void closeAll()
        {
            try
            {
                driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}