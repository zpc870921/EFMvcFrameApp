using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace EFMvcFrame.FrameWork
{
    public class WcfUtility 
    {
        /// <summary>
        /// WCF REQUEST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public static T WCFInvoke<T>(string clientName)
        {
            if (!string.IsNullOrEmpty(clientName)) {
                var factory = new ChannelFactory<T>(clientName);
                return factory.CreateChannel();
            }
            return default(T);
        }


        /// <summary>
        /// webapi Request
        /// </summary>
        /// <param name="baseAddress">基地址</param>
        /// <param name="mediaType">请求类型("application/json")</param>
        /// <returns></returns>
        public static HttpClient ClientInvoke(string baseAddress, string mediaType = "application/json")
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            return httpClient;
        }
    }
}
