using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;


namespace EFMvcFrame.FrameWork.Caching
{

    public class CacheProvider : ICacheProvider
    {
        private static readonly string RedisHost = ConfigurationManager.AppSettings["redishost"];

        private static object LockObj = new object();

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public T Get<T>(string key, Func<T> func)
        {
            using (var client = new RedisClient(RedisHost))
            {

                if (!client.ContainsKey(key))
                {
                    lock (LockObj)
                    {
                        if (!client.ContainsKey(key))
                        {
                            T obj = func();
                            if (null == obj) {
                                obj = default(T);
                            }
                            client.Set<T>(key, obj);     
                            return obj;
                        }
                    }
                }
                return client.Get<T>(key);

            }
        }


        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            using (var client = new RedisClient(RedisHost))
            {
                client.Remove(key);
            }
        }
    }
}
