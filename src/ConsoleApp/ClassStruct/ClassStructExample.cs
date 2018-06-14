using System;
using ConsoleApp.Base;

namespace ConsoleApp.ClassStruct
{
    public class ClassStructExample : IDo
    {
        public void Do()
        {
            var a = AClass.StaticValue;
            var b = AStaticClass.StaticValue;

            var classInstance = new AClass("Class");
            Console.WriteLine($"Class value: {classInstance.Value}");

            var structInstance = new AStruct("Struct");
            Console.WriteLine($"Struct value: {structInstance.Value}");
        }

        private static class AStaticClass
        {
            public static string StaticValue = "Title";
        }

        private class AClass
        {
            public static string StaticValue = "Title";
            public string Value { get; }

            public AClass(string value)
            {
                Value = value;
            }
        }

        private struct AStruct
        {
            public readonly string Value;

            public AStruct(string value)
            {
                Value = value;
            }
        }
    }
}
