using System;
using ConsoleApp.Base;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.Linq
{
    public class ExtensionMethodsExample : IDo
    {
        public void Do()
        {
            A a = null;
            var isEven1 = a.IsEvent1();
            var isEven2 = a.IsEvent2();
            var isEven3 = Extensions.IsEvent2(a);
        }
    }

    public class A
    {
        public int Value { get; set; }

        public bool IsEvent1()
        {
            return Value % 2 == 0;
        }
    }

    public static class Extensions
    {
        public static bool IsEvent2(this A obj)
        {
            if (obj == null)
                return false;

            return obj.Value % 2 == 0;
        }
    }
}
