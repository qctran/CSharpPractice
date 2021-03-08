using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<string> PrepData()
        {
            var data = new List<string>
            { 
                @"https:\\www.yahoo.com",
                @"https:\\www.microsoft.com",
                @"https:\\www.amazon.com",
                @"https:\\www.cnn.com",
                @"https:\\stackoverflow.com"
            };

            return data;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = string.Empty;
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            await RunDownloadAsync();

            stopWatch.Stop();
            Output.Text += $"Total time: {stopWatch.ElapsedMilliseconds/1000}s\r\n";
        }

        //private void RunDownloadAsync()
        private async Task RunDownloadAsync()
        {
            var websites = PrepData();

            foreach (var site in websites)
            {
                //var results = DownloadWebSiteAsync(site);
                WebsiteDataModel results = await Task.Run(() => DownloadWebSiteAsync(site));
                ReportWebsiteInfo(results);
            }
        }

        private void ReportWebsiteInfo(WebsiteDataModel results)
        {
            Output.Text += $"URL: {results.WebsiteUrl} {results.WebsiteData.Length} characters long.\r\n";
        }

        private WebsiteDataModel DownloadWebSiteAsync(string url)
        {
            var output = new WebsiteDataModel();
            System.Net.WebClient client = new System.Net.WebClient();

            output.WebsiteUrl = url;
            output.WebsiteData = client.DownloadString(url);
            return output;
        }

        private async void Modify_Click(object sender, RoutedEventArgs e)
        {
            _msg = "Bye";
        }

        private async void Abort_Click(object sender, RoutedEventArgs e)
        {
            _abort = true;
        }

        private async void Infinit_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = string.Empty;

            await RunInfiniteLoop();
        }

        private bool _abort;
        private string _msg = "Started";
        public delegate void InvokeDelegate();

        private async Task RunInfiniteLoop()
        {
            await Task.Run(() => RunInfinitLoopAsync());

        }

        private void RunInfinitLoopAsync()
        {
            while (!_abort)
            {
                Console.WriteLine($"Message: {_msg}\r\n");
                //Dispatcher.BeginInvoke(new Action(delegate ()
                //{
                //    Output.Text += $"Message: {_msg}\r\n";
                    
                //}));

                //MyList.Dispatcher.BeginInvoke(new Action(delegate ()
                //{
                //    MyList.Items.Add($"Message: {_msg}");
                //    //Output.Text += $"Message: {_msg}\r\n";
                //}));
                Task.Delay(1000);
            }
        }
    }
}
