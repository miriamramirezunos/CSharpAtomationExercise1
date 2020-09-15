using System;
using E1CSharpAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise1CSharpA
{
    [TestClass]
    public class unitTest1
    {
        [TestMethod]
        public void myUnitTest()
        {
            try
            {
                var mySetUp = new unitTestSetUp();
                mySetUp.SetUpMethod(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}