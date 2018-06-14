using System;
using System.Linq;
using ConsoleApp.Base;

namespace ConsoleApp.Reflection
{
    public class AttributesExample : IDo
    {
        public void Do()
        {
            var instance = new TestClass
            {
                Value1 = "1",
                Value2 = "2"
            };

            var awesomeProperties = instance
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(AwesomeAttribute), true).Any())
                .ToArray();

            var awesomeAttributes = awesomeProperties
                .Select(x =>
                    x.GetCustomAttributes(typeof(AwesomeAttribute), true)
                    .Single())
                .Cast<AwesomeAttribute>()
                .ToArray();

            var awesomePropertyValues = awesomeProperties.Select(x => x.GetValue(instance)).ToArray();
        }

        private class TestClass
        {
            [Awesome("because")]
            public string Value1 { get; set; }

            public string Value2 { get; set; }
        }

        [AttributeUsage(AttributeTargets.Property)]
        private class AwesomeAttribute : Attribute
        {
            public string WhySoAwesome { get; }

            public AwesomeAttribute(string whySoAwesome)
            {
                WhySoAwesome = whySoAwesome;
            }
        }
    }
}
