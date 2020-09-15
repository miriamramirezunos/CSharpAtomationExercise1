using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1CSharpAutomation
{
    public class methodsClass : IuserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
