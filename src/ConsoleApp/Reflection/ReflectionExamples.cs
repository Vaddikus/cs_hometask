using System;
using System.Reflection;
using ConsoleApp.Base;

namespace ConsoleApp.Reflection
{
    public class ReflectionExamples : IDo
    {
        public void Do()
        {
            // Instance creation
            var instance1 = Activator.CreateInstance<TestClass>();
            var instance2 = Activator.CreateInstance(typeof(TestClass));
            var instance3 = Activator.CreateInstance(typeof(TestClass), "myKey", "myValue");

            var publicMethodInfo = typeof(TestClass).GetMethod("PublicMethod");
            var publicMethodWithParameterInfo = typeof(TestClass).GetMethod("PublicMethodWithParameter");
            var privateMethodInfo = typeof(TestClass).GetMethod("PrivateMethod");

            var result1 = publicMethodInfo.Invoke(instance3, new object[0]);
            var result2 = publicMethodWithParameterInfo.Invoke(instance3, new object[] {"test"});
            var result3 = privateMethodInfo.Invoke(instance3, new object[] { });

            var keyProperty = typeof(TestClass).GetProperty("Key");
            var keyPropertyValue = keyProperty.GetValue(instance3);
            keyProperty.SetValue(instance3, "my new key");
        }

        private class TestClass
        {
            public TestClass()
            {
            }

            public TestClass(string key, string value)
            {
                Key = key;
                Value = value;
            }

            public string Key { get; set; }

            public string Value { get; set; }

            private void PrivateMethod()
            {
                Console.WriteLine($"PrivateMethod call. Key: {Key}, Value: {Value}");
            }


            public void PublicMethod()
            {
                Console.WriteLine($"PublicMethod call. Key: {Key}, Value: {Value}");
            }

            public string PublicMethodWithParameter(string parameter)
            {
                Console.WriteLine($"PublicMethod call. Parameter: {parameter}");
                return parameter;
            }
        }
    }
}
