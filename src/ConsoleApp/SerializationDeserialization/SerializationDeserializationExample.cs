using ConsoleApp.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp.SerializationDeserialization
{
    public class SerializationDeserializationExample : IDo
    {
        public void Do()
        {
            TestJsonSerialization();
        }

        private void TestJsonSerialization()
        {
            var model = new JsonModel
            {
                Key = "My key", Value = "My value"
            };

            var jsonString = JsonConvert.SerializeObject(model);
            var deserialized = JsonConvert.DeserializeObject<JsonModel>(jsonString);

            var obj = JObject.Parse(jsonString);
            var minJson = @"{""Value"":""My value"",""Key"":""My key""}";
            var isEqual = JToken.DeepEquals(obj, JObject.Parse(minJson));
        }

        private class JsonModel
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}
