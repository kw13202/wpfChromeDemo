using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using WebClient.Helper;
using WebClient.Model;
using Path = System.IO.Path;

namespace WebClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            string url = AppSettingsHelper.GetStringByKey("configUrl", "");
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("请先配置configUrl项");
                return;
            }
            string strJson = await HttpClientHelper.Get(url);
            if (string.IsNullOrEmpty(strJson))
            {
                MessageBox.Show("读取服务配置失败");
                return;
            }
            var config = JsonHelper.DeserializeObject<ServerConfig>(strJson);

            this.Title = config.Title;
            var setting = new CefSettings()
            {
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            if (Cef.IsInitialized == false)
                Cef.Initialize(setting, performDependencyCheck: true, browserProcessHandler: null);

            WpfBrowser.MenuHandler = new MenuHandler();
            WpfBrowser.Address = config.Url;
        } 
        #endregion
    }
}
