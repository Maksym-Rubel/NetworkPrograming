using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;


namespace _08_HttpClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelDownload model;
        
        string folderPath = "";
        public MainWindow()
        {

            InitializeComponent();
            model = new ViewModelDownload()
            {
                
                Progress = 0
            };
           
            this.DataContext = model;

        }

        private void OpenFolderBtn(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                folderPath = dialog.FileName;
            }
        }

        private void DownoloadingButton(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(srcTextBox.Text))
            {
                DowloadFileAsync(srcTextBox.Text);
            }
        }

        
        private async void DowloadFileAsync(string text)
        {
            WebClient client = new WebClient();

            string fileName = Path.GetFileName(text);
            DownloadProcessesInfo info = new DownloadProcessesInfo(fileName);
            info.Client = client;
            model.AddProcess(info);

            client.DownloadProgressChanged += (s, e) =>
            {
                info.Percentage = e.ProgressPercentage;
            };

            client.DownloadFileCompleted += (s, e) =>
            {
                if (e.Cancelled)
                {
                    info.Percentage = 0;
                    MessageBox.Show("Canceled");
                    return;
                }


                info.Percentage = 100;
                MessageBox.Show("Completed!");
            };

            try
            {
                await client.DownloadFileTaskAsync(text, $@"{folderPath}\{fileName}");
            }
            catch (Exception ex)
            {
                
            }
        }



        [AddINotifyPropertyChangedInterface]
        public class ViewModelDownload
        {
            private ObservableCollection<DownloadProcessesInfo> processes;
            public string Source { get; set; }
            public string Destination { get; set; }
            public double Progress { get; set; }
            public bool IsWaiting => Progress == 0;

            public ViewModelDownload()
            {
                processes = new ObservableCollection<DownloadProcessesInfo>();
            }
            public IEnumerable<DownloadProcessesInfo> Processes => processes;
            public void AddProcess(DownloadProcessesInfo info)
            {
                processes.Add(info);
            }
        }


        [AddINotifyPropertyChangedInterface]
        public class DownloadProcessesInfo
        {
            public string FileName { get; set; }
            public double Percentage { get; set; }
            public int PercentageInt => (int)Percentage;
            public double BytesPerSecond;
            public double MegaBytesPerSeconds => Math.Round(BytesPerSecond / 1024 / 1024);
            public WebClient Client { get; set; }
            public DownloadProcessesInfo(string filename)
            {
                FileName = filename;
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string path = "";
            list.SelectedItems.ToString();
            foreach(var item in list.SelectedItems)
            {
                var file = item as DownloadProcessesInfo;
                MessageBox.Show(file.FileName);

                path = Path.Combine(folderPath, file.FileName);
            }
            MessageBox.Show(path);
            Process.Start("explorer.exe", path);

        }
    
        private void StopBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var info = (DownloadProcessesInfo)list.SelectedItem;
                if (info != null && info.Client != null)
                {
                    info.Client.CancelAsync();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            
        }
    }
}