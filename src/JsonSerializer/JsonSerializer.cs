using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace JsonSerializer
{
    public class JsonSerializer : IJsonSerializer
    {
        string json = "";

        public string SerializeObject(object value)
        {

            if (value == null)
            {
                json += "null";
                //return json;
            }
            else
            {
                Type type = value.GetType();
                if (json.Length < 1)
                {
                    json += "{";
                }
                if (type == typeof(string) || type == typeof(Guid))
                {
                    json += @"""" + value.ToString() + @"""";
                }
                else if (type == typeof(DateTime))
                {

                    json += @"""" + ((DateTime)value).ToString("o") + @"""";
                }
                else if (type.IsPrimitive)
                {
                    json += value.ToString();
                }
                else if (type.IsArray)
                {
                    json += "[";
                    foreach (var x in (Array)value)
                    {
                        json += SerializeObject(x) + ",";
                    }
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
                else if (value is IList)
                {
                    json += "[";
                    foreach (var x in (IList)value)
                    {
                        json += SerializeObject(x) + ",";
                    }
                    json = json.Remove(json.Length - 1);
                    json += "]";
                }
                else if (value is IDictionary)
                {
                    json += "{";
                    foreach (DictionaryEntry x in (IDictionary)value)
                    {
                        json += SerializeObject(x.Key) + ":" + SerializeObject(x.Value) + ",";
                    }
                    json = json.Remove(json.Length - 1);
                    json += "}";
                }
                else
                {
                   
                    var testEntity = Activator.CreateInstance(type);
                    testEntity = value;
                    var properties = testEntity.GetType().GetProperties();
                    if (properties != null)
                    {
                        foreach (var property in properties)
                        {
                            json += property.Name + ":" + SerializeObject(property.GetValue(testEntity));
                        }
                    }
                }
            }
            return json;
        }

        
    }
}