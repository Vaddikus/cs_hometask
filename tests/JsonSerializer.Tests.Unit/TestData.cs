using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace JsonSerializer.Tests.Unit
{
    public static class TestData
    {
        public static class Primitive
        {
            public static readonly string String = "Test string";
            public static readonly int Int = int.MaxValue;
            public static readonly long Long = long.MaxValue;
            public static readonly DateTime DateTime = DateTime.UtcNow;
            public static readonly Guid Guid = Guid.NewGuid();

            public static readonly int[] IntArray = Enumerable.Range(0, 5).ToArray();
            public static readonly List<string> StringList = new List<string> { "this", "is", "test" };

            public static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>
            {
                {"key1", "value1"},
                {"key2", "value2"},
                {"key3", "value3"}
            };
        }

        public static class Complex
        {
            public static readonly TestEntity TestEntity = new TestEntity
            {
                Id = 234234124123413,
                OptionalId = 4123342,
                UniqueId = Guid.NewGuid(),
                FullName = "Test Entity Root",
                Tags = new[] { "this", "is", "test" },
                SuperSecretDoNotSerialize = "you failed",
                Children = new[] { new TestEntity(1, "Test Entity Child[1]"), new TestEntity(1, "Test Entity Child[2]") },
                StrangeMapping = new Dictionary<string, Dictionary<DateTime, TestEntity>>
                {
                    { "strangeKey1",
                        new Dictionary<DateTime, TestEntity>
                        {
                            { DateTime.UtcNow.AddHours(1), new TestEntity(34234, "strangeKey1 - child[1]") },
                            { DateTime.UtcNow.AddDays(-1), new TestEntity(34234, "strangeKey1 - child[2]") { SuperSecretDoNotSerialize = "super secret password" } }
                        }
                    },
                    { "strangeKey2",
                        new Dictionary<DateTime, TestEntity>
                        {
                            { DateTime.UtcNow.AddSeconds(500), new TestEntity(34234, "strangeKey2 - child[1]") },
                            { DateTime.UtcNow.AddMonths(-1), new TestEntity(34234, "strangeKey2 - child[2]") },
                            { DateTime.UtcNow.AddHours(5), new TestEntity(34234, "strangeKey2 - child[3]") },
                        }
                    }
                }
            };
        }

        public class TestEntity
        {
            public TestEntity()
            {
            }

            public TestEntity(int id, string fullName)
            {
                Id = id;
                FullName = fullName;
                UniqueId = Guid.NewGuid();
            }

            [JsonProperty("id")]
            public long Id { get; set; }

            public int? OptionalId { get; set; }

            public Guid UniqueId { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("TaGs")]
            public string[] Tags { get; set; }

            [JsonIgnore]
            public string SuperSecretDoNotSerialize { get; set; }

            public TestEntity[] Children { get; set; }

            public Dictionary<string, Dictionary<DateTime, TestEntity>> StrangeMapping { get; set; }
        }
    }
}
