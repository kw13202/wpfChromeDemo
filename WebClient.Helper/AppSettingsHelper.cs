using System.Configuration;

namespace WebClient.Helper
{
    /// <summary>
    /// 配置获取帮助类
    /// </summary>
    public class AppSettingsHelper
    {
        /// <summary>
        /// 根据Key从配置文件获取Int值--取配置值通用方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetIntByKey(string key, int defaultValue)
        {
            string tempStr = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(tempStr) || !int.TryParse(tempStr, out int tempInt))
            {
                tempInt = defaultValue;//默认 
            }

            return tempInt;
        }

        /// <summary>
        /// 获取字符串配置值--取配置值通用方法
        /// </summary>
        /// <param name="key">配置Key</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetStringByKey(string key, string defaultValue)
        {
            string setValue;

            setValue = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(setValue))
            {
                setValue = setValue.Trim();
            }
            if (string.IsNullOrEmpty(setValue))
            {
                setValue = defaultValue;
            }
            return setValue;
        }
    }
}
