using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WebClient.Helper
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    public class JsonHelper
    {
        private static JsonSerializerSettings setting = new JsonSerializerSettings();
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static JsonHelper()
        {
            setting.NullValueHandling = NullValueHandling.Ignore;
        }
        /// <summary>
        /// 序列化成JSON
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, setting);
        }
        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 读取json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T LoadFile<T>(string filepath)
        {
            T result = default(T);
            if (File.Exists(filepath))
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
                }
            }
            return result;
        }

    }
}
