using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConsoleApp.Base;

namespace ConsoleApp.Collections
{
    public class CollectionsExample : IDo
    {
        private const int Iterations = 10000000;

        private int[] _array = new[] { 1, 2, 3, 2 };
        private List<int> _list = new List<int> { 1, 2, 3 , 2};
        private HashSet<int> _hashSet = new HashSet<int> {1, 2, 3, 2};
        private Stack<int> _stack = new Stack<int>();
        private Queue<int> _queue = new Queue<int>();
        private Dictionary<int, string> _dictionary = new Dictionary<int, string>
        {
            { 1, "value1" },
            { 2, "value2" },
            { 3, "value3" }
        };

        public void Do()
        {
            //TestArrayAndList();
            TestEnumerable();
        }

        private void TestArrayAndList()
        {
            var array = Enumerable.Repeat(1, Iterations).ToArray();
            var arrayAccessStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * 2;
            }

            arrayAccessStopwatch.Stop();
            Console.WriteLine($"Access to array[{Iterations}]: {arrayAccessStopwatch.ElapsedMilliseconds}");

            var list = Enumerable.Repeat(1, Iterations).ToList();
            var listAccessStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i] * 2;
            }

            listAccessStopwatch.Stop();
            Console.WriteLine($"Access to list[{Iterations}]: {listAccessStopwatch.ElapsedMilliseconds}");
        }

        private void TestEnumerable()
        {
            IEnumerable<int> enumerable = _array;

            var a = new A();
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }

        public class A
        {
            private readonly int[] _array = { 1, 2, 3 };

            public IEnumerator GetEnumerator()
            {
                return _array.GetEnumerator();
            }
        }
    }
}
