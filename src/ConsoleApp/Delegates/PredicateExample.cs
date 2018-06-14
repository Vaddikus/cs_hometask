using System;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class PredicateExample : IDo
    {
        public void Do()
        {
            Predicate<int> isEven = x => x % 2 == 0;

            Console.WriteLine($"1 - {isEven(1)}");
            Console.WriteLine($"1 - {isEven(2)}");
        }
    }
}
