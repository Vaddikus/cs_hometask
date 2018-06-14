using System;
using ConsoleApp.Base;

namespace ConsoleApp.Delegates
{
    public class LambdaExample : IDo
    {
        public void Do()
        {
            Func<double, double> pow = x => x * 2;

            Console.WriteLine($"2^2 = {pow(2)}");
        }

        public double A1(double x)
        {
            return x * 2;
        }
    }
}
