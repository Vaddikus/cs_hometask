using System;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class DelegatesExample : IDo
    {
        delegate void Print(string value);

        public void Do()
        {
            var printDelegate = new Print(PrintToConsole);
            printDelegate("Hello delegate");

            var anonymousDelegate = new Print(delegate (string value)
            {
                Console.WriteLine(value);
            });
            anonymousDelegate("Hello anonymous delegate");
        }

        private void PrintToConsole(string value)
        {
            Console.WriteLine(value);
        }
    }
}
