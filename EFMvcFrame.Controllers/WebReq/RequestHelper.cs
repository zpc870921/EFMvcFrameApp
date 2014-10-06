using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.ServiceModel;
using WcfInterface; 
using System.ServiceModel.Channels;
using EFMvcFrame.FrameWork;

namespace EFMvcFrame.Controllers.WebReq
{


    public class RequestHelper
    {
        #region webrequest
        /// <summary>
        /// webrequest
        /// </summary>
        public static void WebRequestTest()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8008/testapi/api/demo/sitelist");
            request.Headers.Add("token", "zoupengcheng3");
            request.Headers.Add("test", "test3");

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.UserAgent = DefaultUserAgent;
            request.Timeout = 5000;
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add()
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("startId", "1");
            dict.Add("itemCount", "3");
            int startIndex = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in dict)
            {
                if (startIndex == 0)
                {
                    sb.AppendFormat("{0}={1}", item.Key, item.Value);
                }
                else
                {
                    sb.AppendFormat("&{0}={1}", item.Key, item.Value);
                }
                startIndex++;
            }
            var datas = Encoding.UTF8.GetBytes(sb.ToString());
            using (Stream s = request.GetRequestStream())
            {
                s.Write(datas, 0, datas.Length);
            }

            var response = request.GetResponse() as HttpWebResponse;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                var sites = JArray.Parse(sr.ReadToEnd());
                if (sites != null && sites.Any())
                {
                    foreach (var item in sites)
                    {
                        Console.WriteLine("{0},{1},{2}", item["Id"].ToString(), item["Title"].ToString(), item["Url"].ToString());
                    }
                }
            }
        }
        #endregion
         

        #region webapi request
        /// <summary>
        /// webapi Request
        /// </summary>
        public static void WebApiTest()
        {
            using (var client = WcfUtility.ClientInvoke("http://localhost:8008/testapi/"))
            {
                var response = client.GetAsync("api/demo/sitelist").Result;

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);
                    foreach (var item in data)
                    {
                        Console.WriteLine("{0},{1},{2}", item["Id"].ToString(), item["Title"].ToString(), item["Url"].ToString());
                    }
                }
                else
                {
                    //请求出错
                }
            }
            #region 注释
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:8008/testapi/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    var response=client.GetAsync("api/demo/sitelist").Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);
            //        foreach (var item in data)
            //        {
            //            Console.WriteLine("{0},{1},{2}",item["Id"].ToString(),item["Title"].ToString(),item["Url"].ToString());
            //        }
            //    }
            //    else { 
            //        //请求出错
            //    }

            //}
            #endregion
        }
        #endregion


        #region wcf request
        /// <summary>
        /// wcf request
        /// </summary>
        public static void wcftest()
        {
            //var binding = new BasicHttpBinding();
            //binding.TransactionFlow = true;
            //binding.Security.Mode = SecurityMode.None;
            //"wsHttpBinding_IServiceTest"
            //var pointAddress=new EndpointAddress("http://localhost/ProductService/ProductService.svc");
            //var serviceSvc = ChannelFactory<IServiceTest>.CreateChannel(binding,pointAddress);
            //var factory = new ChannelFactory<IServiceTest>("basicHttpBinding_IServiceTest");
            //IServiceTest svcClient = factory.CreateChannel();





            var svcClient = WcfUtility.WCFInvoke<IServiceTest>("basicHttpBinding_IServiceTest");

            var product= svcClient.GetProductById(1);

            var result = svcClient.AddProduct(new ServiceModel.Product { Id = 5, Cost = 50, Name = "50202020" });


        }

        #endregion
    }
}
