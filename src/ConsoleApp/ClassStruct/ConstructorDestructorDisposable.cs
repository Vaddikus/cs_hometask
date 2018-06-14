using System;
using ConsoleApp.Base;

namespace ConsoleApp.ClassStruct
{
    public class ConstructorDestructorDisposable : IDo
    {
        public void Do()
        {
            //var keyValue = new MyKeyValue("key", "value");
            //keyValue = null;

            using (var obj = new MyKeyValueDisposable("key", "value"))
            {
                var a = obj.Value;
            }
        }

        private class BaseValue
        {
            public string Value { get; }

            public BaseValue(string value)
            {
                Console.WriteLine("Constructor: BaseValue");
                Value = value;
            }

            ~BaseValue()
            {
                Console.WriteLine("BaseValue: destructor");
            }
        }

        private class MyKeyValue : BaseValue
        {
            public string Key { get; }

            public MyKeyValue(string key, string value)
                : base(value)
            {
                Console.WriteLine("Constructor: MyKeyValue");
                Key = key;
            }

            ~MyKeyValue()
            {
                Console.WriteLine("MyKeyValue: destructor");
            }
        }

        private class MyKeyValueDisposable : MyKeyValue, IDisposable
        {
            public MyKeyValueDisposable(string key, string value)
                : base(key, value)
            {
                Console.WriteLine("Constructor: MyKeyValueDisposable");
            }
            public void Dispose()
            {
                Console.WriteLine("MyKeyValueDisposable: Dispose");
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposing)
                    return;

                // Dispose unmanaged resources
            }
        }
    }
}
