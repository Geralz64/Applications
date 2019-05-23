using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public delegate int BusinessRules(int x, int y);

    class ProcessData
    {
        public void Process(int x, int y, BusinessRules del)
        {
            var result = del(x, y);
            Console.WriteLine(result);

        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del(x, y);
            Console.WriteLine(result);

        }


        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been processed");
        }

    }
}
