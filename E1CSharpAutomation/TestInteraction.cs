using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace E1CSharpAutomation
{
    class TestInteraction
    {
        // Region to create and declare WebElements
        #region my elements definition
        By textDisplayed = By.CssSelector("body div:nth-of-type(3)>div>div>div>div>div:nth-of-type(2)");
        By createNewAccountButton = By.CssSelector("#u_0_2");
        By firstNameInput = By.CssSelector("#reg_form_box>div>div>div>div:nth-of-type(1)>input:nth-of-type(1)");
        By lastNameInput = By.CssSelector("#reg_form_box>div>div>div>div>div>input");
        By phoneNumber = By.CssSelector("#reg_form_box>div:nth-of-type(2) input");
        By ElementDoesNotExists = By.CssSelector("#noexisting");
        #endregion
        public void GoToFacebookPage(IWebDriver driver)
        {
            // Go to facebook.com
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        public void VerifyTextDisplayed(IWebDriver driver)
        {
            // Verify text is displayed using Custom Assert to print successful validation message
            var ValidateText = new CustomAssert();
            var ExpectedText = "It’s quick and easy.";
            WaitWebElement(createNewAccountButton, driver);
            ClickWebElement(createNewAccountButton, driver);
            WaitWebElement(textDisplayed, driver);
            ValidateText.IsTheSameText(driver.FindElement(textDisplayed).Text.ToString(), ExpectedText);
        }

        public void FillInformation(IWebDriver driver)
        {
            // Fill information and log the action on console
            WaitWebElement(firstNameInput, driver);
            SendKeysWebElement(firstNameInput, driver, "Miriam", "First Name");
            WaitWebElement(lastNameInput, driver);
            SendKeysWebElement(lastNameInput, driver, "Ramirez", "Last Name");
            WaitWebElement(phoneNumber, driver);
            SendKeysWebElement(phoneNumber, driver, "1234567890", "Phone Number");
        }

        public void WaitForElementDoesNotExist(IWebDriver driver)
        {
            // exception handler to catch the exception and display a customized message for elements that do not exist. 
            WaitWebElement(ElementDoesNotExists, driver, true);
        }

        // Interaction Methods
        // Method overloaded
        void WaitWebElement(By byElement, IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementExists(byElement));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        // Method overloaded
        void WaitWebElement(By byElement, IWebDriver driver, Boolean readableMessage)
        {
            try
            {
                ExistsWebEment(byElement, driver);
            }
            catch (CustomException ex)
            {
                Console.WriteLine("Custom Exception Message. Error = {0}.", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        void ClickWebElement(By byElement, IWebDriver driver)
        {
            try
            {
                driver.FindElement(byElement).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        void SendKeysWebElement(By byElement, IWebDriver driver, String strValue, String whatElement)
        {
            try
            {
                driver.FindElement(byElement).SendKeys(strValue);
                Console.WriteLine("Filled Field: {0} with value: \"{1}\"", whatElement, strValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        void ExistsWebEment(By byElement, IWebDriver driver)
        {
            if (driver.FindElements(byElement).Count == 0)
            {
                throw new CustomException("Web Element does not exists");
            }
            else
            {
                Console.WriteLine("Element exists");
            }
        }
    }
}