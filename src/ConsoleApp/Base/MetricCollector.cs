using System;
using System.Diagnostics;

namespace ConsoleApp.Base
{
    public class MetricCollector
    {
        public void PrintMetrics(IDoAndDoNot instance)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"{instance.GetType().Name}:\n\r");
            if(instance.Iterations.HasValue)
                Console.WriteLine($"Iterations: {instance.Iterations.Value}");

            var doStopWatch = Stopwatch.StartNew();
            instance.Do();
            doStopWatch.Stop();

            Console.WriteLine($"Do: {doStopWatch.ElapsedMilliseconds}");

            var doNotStopWatch = Stopwatch.StartNew();
            instance.DoNot();
            doNotStopWatch.Stop();

            Console.WriteLine($"DoNot: {doNotStopWatch.ElapsedMilliseconds}");
        }
    }
}
