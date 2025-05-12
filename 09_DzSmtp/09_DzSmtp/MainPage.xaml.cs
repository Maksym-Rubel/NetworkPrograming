using Microsoft.Win32;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace _09_DzSmtp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        const string server = "smtp.gmail.com";
        const short port = 587;
        string username = "";
        string password = "";
        //string username = "rubelmaksum2404@gmail.com";
        //string password = "jzim fujc jnpl eckm";

        BestViewModel model;
        public MainPage(string uesrname1,string password1,string owner)
        {
            InitializeComponent();
            model = new BestViewModel();
            this.DataContext = model;
            username = uesrname1;
            password = password1;
            toBox.Text = owner;
        }
        private void SelectFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                ViewModel file = new ViewModel(dialog.FileName);
                model.AddProcess(file);
            }

        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage(username, toBox.Text, themeBox.Text, GetRichText(messageBox));

            message.Priority = priorityCheckBox.IsChecked == true ? MailPriority.High : MailPriority.Normal;


            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    message.Attachments.Add(new Attachment(file.FileName));
                }
            }
            SmtpClient client = new SmtpClient(server, port);
            client.Credentials = new NetworkCredential(username, password);
            client.EnableSsl = true;
            client.SendAsync(message, message);

            client.SendCompleted += SendMessageCompleted;

            foreach (var file in model.Files.ToList())
            {
                model.DeleteProcess(file);
            }


        }

        private void SendMessageCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            MessageBox.Show("Complete");
        }

        string GetRichText(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(
                richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd
            );
            return textRange.Text;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteOne(object sender, RoutedEventArgs e)
        {

            foreach (var file in listFiles.SelectedItems.Cast<ViewModel>().ToList())
            {
                model.DeleteProcess(file);
            }

        }

        private void priorityCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMailPage(username, password));
        }
    }


    public class BestViewModel
    {
        private ObservableCollection<ViewModel> files;
        public BestViewModel()
        {
            files = new ObservableCollection<ViewModel>();
        }
        public IEnumerable<ViewModel> Files => files;


        public void AddProcess(ViewModel info)
        {
            files.Add(info);
        }
        public void DeleteProcess(ViewModel info)
        {
            files.Remove(info);
        }
    }
    public class ViewModel
    {
        public string FileName { get; set; }
        public ViewModel(string fileName)
        {
            FileName = fileName;
        }
    }
}
