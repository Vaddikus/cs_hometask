using System;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class FunctionsExample : IDo
    {
        public void Do()
        {
            Func<bool> getTrue = () => true;
            Func<int, bool> isEven = x => x % 2 == 0;

            Console.WriteLine($"getTrue: {getTrue()}");
            Console.WriteLine($"isEvent[1] - {isEven(1)}");
            Console.WriteLine($"isEvent[2] - {isEven(2)}");
        }
    }
}
