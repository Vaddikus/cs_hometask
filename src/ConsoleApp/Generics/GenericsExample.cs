using System;
using System.Collections.Generic;
using ConsoleApp.Base;

namespace ConsoleApp.Generics
{
    public class GenericsExample : IDo
    {
        public void Do()
        {
            //TestCache();
            TestStaticCache();
        }

        public void TestCache()
        {
            var storage1 = new MyCache<int, string>();

            var containsBefore1 = storage1.Contains(1);
            storage1.Upsert(1, "value1");
            var containsAfter1 = storage1.Contains(1);
            var value1 = storage1.Get(1);

            var storage2 = new MyCache<int, string>();

            var containsBefore2 = storage2.Contains(1);
            storage2.Upsert(1, "value2");
            var containsAfter2 = storage2.Contains(1);
            var value2 = storage2.Get(1);
        }

        private void TestStaticCache()
        {
            //var storage1 = new MyStaticCache<string>();

            //var containsBefore1 = storage1.Contains(1);
            //storage1.Upsert(1, "value1");
            //var containsAfter1 = storage1.Contains(1);
            //var value1 = storage1.Get(1);

            var storage2 = new MyStaticCache<A>();

            storage2.Upsert(1, new A());
        }

        private class MyCache<TKey, TValue>

        {
            private readonly Dictionary<TKey, TValue> _store = new Dictionary<TKey, TValue>();

            public bool Contains(TKey id)
            {
                return _store.ContainsKey(id);
            }

            public TValue Get(TKey id)
            {
                _store.TryGetValue(id, out var value);
                return value;
            }

            public void Upsert(TKey id, TValue value)
            {
                _store[id] = value;
            }
        }

        public class A : ICacheItem
        {
            public DateTime Expiration { get; } = DateTime.Now.AddDays(1);
        }

        public class B : ICacheItem
        {
            public DateTime Expiration { get; } = DateTime.Now.AddDays(1);
        }

        public interface ICacheItem
        {
            DateTime Expiration { get; }
        }

        private class MyStaticCache<T>
            where T : ICacheItem
        {
            private static readonly Dictionary<int, T> Store = new Dictionary<int, T>();

            public void Upsert(int id, T value)
            {
                Store[id] = value;
            }
        }
    }
}
