﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E1CSharpAutomation
{
    class unitTestCustomAssert
    {
        // Custom Assert to print successful validation message
        public void isTheSameText(String actual, String expected)
        {
            if (actual.Trim() == expected.Trim())
            {
                Console.WriteLine($"Custom Assert. Successful Assert! The text \"{actual}\" is equal to \"{expected}\"");
            }
            else
            {
                throw new unitTestCustomException($"Custom Exception Message. Custom Assert. Failed Assert: The text \"{actual}\" is different compared with \"{expected}\"");
            }
        }
    }
}
