using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
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
                //Source = @"https://sun-inside.me/wp-content/uploads/2020/02/Screenshot-2020-02-26-at-17.20.42-682x1024.png",
                //Destination = @"C:\Users\Maksym\Desktop\Test",
                Progress = 0
            };
            //folderPath = model.Destination;
            //srcTextBox.Text = model.Source;
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

            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            //client.DownloadFileCompleted += Client_DownloadFileCompleted;


            string fileName = Path.GetFileName(text);
            DownloadProcessesInfo info = new DownloadProcessesInfo(fileName);
            model.AddProcess(info);

            await client.DownloadFileTaskAsync(text, $@"{folderPath}\{fileName}");
            info.Percentage = 100;

        }


        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            model.Progress += e.ProgressPercentage;
            //var fileName = Path.GetFileName(e.UserState.ToString());
            //var info = model.Processes.FirstOrDefault(p => p.FileName == fileName);
            //if (info != null)
            //{
            //    info.BytesPerSecond = e.BytesReceived;
            //}

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

            public DownloadProcessesInfo(string filename)
            {
                FileName = filename;
            }
        }
    }
}