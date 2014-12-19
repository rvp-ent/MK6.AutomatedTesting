using System.Collections.Generic;

namespace MK6.AutomatedTesting.Runner
{
    public static class Extensions
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> newItems)
        {
            foreach (var newItem in newItems)
            {
                list.Add(newItem);
            }
        }

        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, 
            IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
            {
                dictionary.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return dictionary;
        }

        public static IDictionary<TKey, TValue> Add<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            KeyValuePair<TKey, TValue> keyValue)
        {
            dictionary.Add(keyValue);
            return dictionary;
        }
    }
}
