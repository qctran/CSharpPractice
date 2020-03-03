using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleAsyncDemo
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

        private void Button_Sync_Click(object sender, RoutedEventArgs e)
        {
            syncBtn.IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            var result = DemoMethods.RunDownloadSync();

            sw.Stop();
            PrintResults(result);
            output.Text += $"Total time: " + sw.Elapsed;
            syncBtn.IsEnabled = true;
        }

        private async void Button_Async_Click(object sender, RoutedEventArgs e)
        {
            asyncBtn.IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            var result = await DemoMethods.RunDownloadAsync();

            sw.Stop();
            PrintResults(result);
            output.Text += $"Total time: " + sw.Elapsed;
            asyncBtn.IsEnabled = true;
        }

        private async void Button_Async_With_Cancel_Click(object sender, RoutedEventArgs e)
        {
            asyncBtn.IsEnabled = false;
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                //var result = await DemoMethods.RunDownloadAsync(_cts.Token);

                sw.Stop();
                //PrintResults(result);
            }
            catch (Exception)
            {
                output.Text += "User cancel";
            }
            output.Text += $"Total time: " + sw.Elapsed;
            asyncBtn.IsEnabled = true;
        }
        private async void Button_Async_Progress_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            asyncBtnAndProgress.IsEnabled = false;
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += UpdateDefaultStyle;
            var sw = new Stopwatch();
            sw.Start();
            var result = DemoMethods.RunDownloadParallelSync();
            
            sw.Stop();
            output.Text += $"Total time: " + sw.Elapsed;


            asyncBtnAndProgress.IsEnabled = true;
        }

        private async void Button_Async_V2_Progress_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            asyncBtnAndProgress.IsEnabled = false;
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += UpdateDefaultStyle;
            var sw = new Stopwatch();
            sw.Start();
            var result = DemoMethods.RunDownloadParallelAsyncV2(progress);

            sw.Stop();
            output.Text += $"Total time: " + sw.Elapsed;


            asyncBtnAndProgress.IsEnabled = true;
        }

        private void UpdateDefaultStyle(object sender, ProgressReportModel e)
        {
            ProgressBar.Value = e.PercentageComplete;
            PrintResults(e.SitesDownloaded);
        }

        private CancellationTokenSource _cts = new CancellationTokenSource();
        private async Task ExecuteLongProcessAsync()
        {
            IProgress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            await DemoMethods.RunDownloadAsync(progress, _cts.Token);
        }
        
        private void PrintResults(List<WebsiteDataModel> results)
        {
            output.Text = string.Empty;
            foreach (var item in results)
            {
                output.Text +=
                    $"{item.WebsiteUrl} downloaded: {item.WebsiteData.Length} characters long.{Environment.NewLine}";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }
    }
}
