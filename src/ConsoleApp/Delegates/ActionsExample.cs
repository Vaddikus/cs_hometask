using System;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class ActionsExample : IDo
    {
        public void Do()
        {
            Action printHello = () => Console.WriteLine("Hello");
            Action<string> print = x => Console.WriteLine(x);

            printHello();
            print("Hello, world!");
        }
    }
}
