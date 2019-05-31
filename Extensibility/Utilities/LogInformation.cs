using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class LogInformation
    {

        #region Methods

        public static string LogInfoStart()
        {

            StackTrace stack = new StackTrace();

            return stack.GetFrame(1).GetMethod().Name.ToString();

        }

        public static void LogInfoEnd()
        {

            LogInformation.LogInfoStart();

            Console.WriteLine($"Process completed at {DateTime.Now}");

        }

        #endregion
    }
}
