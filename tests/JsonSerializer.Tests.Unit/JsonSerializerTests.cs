using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using Xunit;
using Xunit.Abstractions;

namespace JsonSerializer.Tests.Unit
{
    public class JsonSerializerTests
    {

        private readonly ITestOutputHelper output;


        public JsonSerializerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Serialize_String_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.String);
        }

        [Fact]
        public void Serialize_Int_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.Int);
        }

        [Fact]
        public void Serialize_Long_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.Long);
        }

        [Fact]
        public void Serialize_DateTime_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.DateTime);
        }

        [Fact]
        public void Serialize_Guid_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.Guid);
        }

        [Fact]
        public void Serialize_IntArray_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.IntArray);
        }

        [Fact]
        public void Serialize_StringList_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.StringList);
        }

        [Fact]
        public void Serialize_Dictionary_ShouldReturnValidJson()
        {
            RunTest(TestData.Primitive.Dictionary);
        }

        [Fact]
        public void Serialize_ComplexType_ShouldReturnValidJson()
        {
            RunTest(TestData.Complex.TestEntity);
        }

        private void RunTest(object value)
        {
            var expectedJson = JsonConvert.SerializeObject(value);
            output.WriteLine("Expected Json: " + expectedJson);
            var actualJson = new JsonSerializer().SerializeObject(value);
            output.WriteLine("Actual Json: " + actualJson);
            if (value.GetType().IsPrimitive
                || value.GetType() == typeof(string)
                || value.GetType() == typeof(Guid)
                || value.GetType() == typeof(DateTime)
                || value.GetType().IsArray
                || value is IList)
            {
                Assert.Equal(expectedJson, actualJson);
            }
            else
            {
                Assert.True(JToken.DeepEquals(JObject.Parse(actualJson), JObject.Parse(expectedJson)));
            }
            }
    }
}
