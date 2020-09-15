using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1CSharpAutomation
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("Console App");
                var userInput = new methodsClass();
                string selection = userInput.GetInput(); 
                //selection = Console.ReadLine();
                Console.WriteLine(selection);
                Console.ReadLine();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error: {0}", ex.Message); 
            }

        }

    }
}
