using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Helper
{
    public class HttpClientHelper
    {
        private static readonly HttpClient _HttpClient = null;

        static HttpClientHelper()
        {
            //允许最大并发链接数
            ServicePointManager.DefaultConnectionLimit = 512;
            HttpClientHandler handler = new HttpClientHandler()
            {
                //请求内容缓冲区大小
                MaxRequestContentBufferSize = 100000,
                //使用GZip压缩解压
                AutomaticDecompression = DecompressionMethods.GZip,
                //是否使用代理
                UseProxy = false,
                //代理设置为空
                Proxy = null,
            };

            _HttpClient = new HttpClient(handler);
        }

        /// <summary>
        /// 通过GET请求获取内容
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="key">HttpClient键</param>
        /// <returns></returns>
        public static async Task<string> Get(string url)
        {
            string result = string.Empty;
            var resp = await _HttpClient.GetAsync(url);
            result = await resp.Content.ReadAsStringAsync();
            return result;
        }

    }
}
