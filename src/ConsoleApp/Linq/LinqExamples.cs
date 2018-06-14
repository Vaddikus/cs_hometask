using System;
using System.Linq;
using ConsoleApp.Base;

namespace ConsoleApp.Linq
{
    public class LinqExamples : IDo
    {
        public void Do()
        {
            TestEnumerable();
            TestLinq();
        }

        private void TestEnumerable()
        {
            var array = new[] { 1, 2, 3 };

            var a = array.Select(x => x * 2);
            var b = a.ToArray();

            Console.WriteLine(string.Join(", ", a));
            Console.WriteLine(string.Join(", ", b));

            for (int i = 0; i < array.Length; i++)
                array[i] *= 2;

            Console.WriteLine(string.Join(", ", a));
            Console.WriteLine(string.Join(", ", b));
        }

        private void TestLinq()
        {
            var array = new[] { 1, 2, 3, 4 };
            var even = array.Where(x => x % 2 == 0).ToArray();

            var top2 = array.Take(2).ToArray();
            var skip2 = array.Skip(2).ToArray();
        }
    }
}
