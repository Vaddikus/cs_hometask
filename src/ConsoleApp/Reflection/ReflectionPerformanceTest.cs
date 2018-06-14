using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleApp.Base;

namespace ConsoleApp.Reflection
{
    public class ReflectionPerformanceTest : IDo
    {
        private const int Iterations = 1000000;
        public void Do()
        {
            var values = Enumerable.Repeat(Guid.NewGuid().ToString(), Iterations).ToArray();
            var testInstance1 = new TestClass();
            PrintExecutionTime("Set value [Standard]", () =>
            {
                foreach (var value in values)
                    testInstance1.Value = value;
            });

            var testInstance2 = new TestClass();
            PrintExecutionTime("Set value [Reflection]", () =>
            {
                var propertyInfo = typeof(TestClass).GetProperty("Value");
                foreach (var value in values)
                    propertyInfo.SetValue(testInstance2, value);
            });

            var testInstance3 = new TestClass();
            PrintExecutionTime("Empty method call [Standard]", () =>
            {
                for (int i = 0; i < Iterations; i++)
                    testInstance3.DoNothing();
            });

            var testInstance4 = new TestClass();
            PrintExecutionTime("Empty method call [Reflection]", () =>
            {
                var methodInfo = typeof(TestClass).GetMethod("DoNothing");
                for (int i = 0; i < Iterations; i++)
                    methodInfo.Invoke(testInstance4, new object[0]);
            });
        }

        private void PrintExecutionTime(string title, Action action)
        {
            Console.WriteLine("-------------------------------------------------------------------------");

            var doStopWatch = Stopwatch.StartNew();
            action();
            doStopWatch.Stop();

            Console.WriteLine($"{title}: {doStopWatch.ElapsedMilliseconds} ms");
        }

        private class TestClass
        {
            public string Value { get; set; }

            public void DoNothing()
            {
            }
        }
    }
}
