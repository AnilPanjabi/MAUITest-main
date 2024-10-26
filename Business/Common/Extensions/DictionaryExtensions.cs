using System;
using System.Collections.ObjectModel;

namespace MAUITest.Business.Common.Extensions
{
    /// <summary>
    /// Extension methods related to Dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// GetQuery Attribute Value from navigation parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <param name="removeAfterRead">If true, removes the key from the dictionary after reading.</param>
        /// <returns></returns>
        public static T GetQueryAttributeValue<T>(this IDictionary<string, object> query, string key, bool removeAfterRead = false) where T : class
        {
            T result = null;

            object value = null;

            if (query?.TryGetValue(key, out value) != null)
            {
                result = (T)value;

                if (removeAfterRead)
                {
                    query.Remove(key);
                }
            }

            return result;
        }

        /// <summary>
        /// This method will take ObservableCollection as parameter and return ObservableCollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <param name="removeAfterRead">If true, removes the key from the dictionary after reading.</param>
        /// <returns></returns>
        public static ObservableCollection<T> GetQueryAttributeValueAsObservableCollection<T>(this IDictionary<string, object> query,
             string key, bool removeAfterRead = false) where T : class, new()
        {
            ObservableCollection<T> result = null;

            object value = null;
            if (query?.TryGetValue(key, out value) != null)
            {
                var data = (List<T>)value;
                result = new ObservableCollection<T>(data);

                if (removeAfterRead)
                {
                    query.Remove(key);
                }
            }

            return result;
        }
    }
}

