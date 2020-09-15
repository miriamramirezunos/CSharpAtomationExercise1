using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using E1CSharpAutomation;
using OpenQA.Selenium;
using System.Linq.Expressions;
using OpenQA.Selenium.Support.UI;

namespace E1CSharpAutomation
{
    public class unitTestSetUp
    {
        public IWebDriver driver;

        // Setup Method
        public void SetUpMethod()
        {
            try
            {  
                // Create and declare WebElements
                #region my elements definition
                By textDisplayed = By.CssSelector("body div:nth-of-type(3)>div>div>div>div>div:nth-of-type(2)");
                By createNewAccountButton = By.CssSelector("#u_0_2"); 
                By firstNameInput = By.CssSelector("#reg_form_box>div>div>div>div:nth-of-type(1)>input:nth-of-type(1)");
                By lastNameInput = By.CssSelector("#reg_form_box>div>div>div>div>div>input");
                By phoneNumber = By.CssSelector("#reg_form_box>div:nth-of-type(2) input");
                By ElementDoesNotExists = By.CssSelector("#noexisting"); 
                #endregion

                var userInput = new unitTestInput();
                Console.WriteLine("Type on unitTestInput.cs \"C\" for Chrome or \"F\" for Firefox");
                String selection = userInput.GetInput();
                Console.WriteLine("The selection is: {0}", selection);
                // Switch to select the browser to be created
                switch (selection)
                {
                    case "C":
                        driver = new ChromeDriver();
                        break;
                    case "F":
                        driver = new FirefoxDriver();
                    break;
                    default:
                        Console.WriteLine("None browser created. Type on unitTestInput \"C\" for Chrome or \"F\" for Firefox");
                        break;
                }
                // Go to facebook.com 
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.facebook.com/");
                // Verify text is displayed 
                var validateText = new unitTestCustomAssert(); 
                var expectedText = "It’s quick and easy.";                 
                waitWebElement(createNewAccountButton);
                clickWebElement(createNewAccountButton); 
                waitWebElement(textDisplayed);
                validateText.isTheSameText(driver.FindElement(textDisplayed).Text.ToString(), expectedText);
                // Fill information and log the action 
                waitWebElement(firstNameInput);
                sendKeysWebElement(firstNameInput, "Miriam", "First Name");
                waitWebElement(lastNameInput);
                sendKeysWebElement(lastNameInput, "Ramirez", "Last Name");
                waitWebElement(phoneNumber);
                sendKeysWebElement(phoneNumber, "1234567890", "Phone Number");
                // Catch exception and display customized message 
                waitWebElement(ElementDoesNotExists, true);
                closeAll(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        // Interaction Methods
        public void waitWebElement(By byElement)
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
        public void waitWebElement(By byElement, Boolean readableMessage)
        {
            try
            {
                existsWebEment(byElement); 
            }
            catch (unitTestCustomException ex)
            {
                Console.WriteLine("Custom Exception Message. Error = {0}.", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
        public void clickWebElement(By byElement)
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

        public void sendKeysWebElement(By byElement, String strValue, String whatElement)
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
        public void existsWebEment(By byElement)
        {
            if (driver.FindElements(byElement).Count == 0)
            {
                throw new unitTestCustomException("Web Element does not exists"); 
            }
            else
            {
                Console.WriteLine("Element exists");
            }
        }

        [Obsolete]
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
