using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E1CSharpAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace E1CSharpAutomation
{
    public class SetUp
    {
        public IWebDriver driver;

        // Setup Method
        public IWebDriver SetUpMethod()
        {
            try
            {  
                var userInput = new CustomInput();
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
                        { 
                            Console.WriteLine("None browser created. Type on unitTestInput \"C\" for Chrome or \"F\" for Firefox");
                            driver = new ChromeDriver();
                        }
                        break;
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            return driver;
        }
    }
}
