using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _09_DzSmtp
{
    /// <summary>
    /// Interaction logic for MainMailPage.xaml
    /// </summary>
    /// 

    public class ViewModel1
    {
        private ObservableCollection<MyMessage> files;
        public string AvattarLetter { get; set; }
        public ViewModel1()
        {
            files = new ObservableCollection<MyMessage>();


        }
        public IEnumerable<MyMessage> Files => files;

        public IMailFolder folder { get; set; }
        public string folderName { get; set; }

        public void AddProceses(IEnumerable<MyMessage> Files1)
        {
            files.Clear();
            foreach (var message in Files1)
            {
                files.Add(message);
            }
        }
        public void AddProcess(MyMessage info)
        {
            files.Add(info);
        }
        public void DeleteProcess(MyMessage info)
        {
            files.Remove(info);
        }
        public void ClearProcess()
        {
            files.Clear();
        }
    }

    public class MyMessage
    {
        public int messageid { get; set; }
        public string messagaSender { get; set; }
        public string messegaInto { get; set; }
        public string messageTime { get; set; }
        public string messageMail { get; set; }

        public string MessegaIntoTrimmed =>
        string.IsNullOrEmpty(messegaInto)
        ? string.Empty
        : (messegaInto.Length > 80 ? messegaInto.Substring(0, 79) + "..." : messegaInto);

        public string MessegaSenderTrimmed =>
        string.IsNullOrEmpty(messagaSender)
        ? string.Empty
        : (messagaSender.Length > 30 ? messagaSender.Substring(0, 29) + "..." : messagaSender);
        public MyMessage(int id, string send, string message, string time, string mail)
        {
            messageid = id;
            messagaSender = send;
            messegaInto = message;
            messageTime = time;
            messageMail = mail;
        }

    }

    public partial class MainMailPage : Page
    {
        string username = "";
        string password = "";
        private string lastSearchText = string.Empty;
        private bool isTyping = false;
        public IEnumerable<MyMessage> FilesTemp;
        CancellationTokenSource cts = new CancellationTokenSource();
        //const string username = "rubelmaksum2404@gmail.com";
        //const string password = "jzim fujc jnpl eckm";
        //const string username2 = "maksimrubel2404@gmail.com";
        //const string password2 = "vjwe vhzg qxvh ogve";
        IMailFolder folder = null;
        string path = "users.json";
        List<LoginData> logins;
        ViewModel1 model;
        public MainMailPage(string username1, string password1)
        {
            InitializeComponent();
            GetFolders();
            //GetMails();
            //GetLoginData();
            model = new ViewModel1();
            this.DataContext = model;

            username = username1;
            password = password1;
            char letters = username.FirstOrDefault();
            string AvatarLetter1 = letters.ToString().ToUpper();
            model.AvattarLetter = AvatarLetter1;
            logins = GetLoginData();
            AddCombobox();
            //myImage1.Source = new BitmapImage(new Uri("pack://application:,,,/MailBackground.jpg"));


        }
        public void AddCombobox()
        {
            foreach (var login in logins)
            {
                CmBox.Items.Add(login.Email);
            }

        }
        //public void GetLoginData()
        //{
        //    string text = File.ReadAllText("users.json");

        //    LoginData users = JsonSerializer.Deserialize<LoginData>(text);
        //    MessageBox.Show($"{users.Email}-{users.Password}");

        //}
        //public static string GetHash(string password)
        //{
        //    byte[] data = Encoding.Unicode.GetBytes(password);
        //    byte[] hash = SHA1.HashData(data);

        //    StringBuilder sb = new StringBuilder();
        //    foreach(byte b in  hash)
        //    {
        //        sb.Append(b.ToString("X2"));
        //    }
        //    return sb.ToString();
        //}
        public List<LoginData> GetLoginData()
        {
            string text = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(text))
                return new List<LoginData>();
            return JsonSerializer.Deserialize<List<LoginData>>(text);
        }
        private void CmBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            string email = CmBox.SelectedItem.ToString();
            string password = "";
            foreach (var login in logins)
            {
                if (email == login.Email)
                {
                    password = login.Password;
                }
            }
            NavigationService.Navigate(new MainMailPage(email, password));
        }
        private async void GetFolders()
        {
            try
            {

                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(username, password);

                    folderList.Items.Clear();
                    foreach (var item in await client.GetFoldersAsync(client.PersonalNamespaces[0]))
                    {
                        folderList.Items.Add(item.Name);
                    }





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void GetMails()
        {
            try
            {


                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(username, password);


                    foreach (var item in await client.GetFoldersAsync(client.PersonalNamespaces[0]))
                    {
                        if (model.folderName == folderList.SelectedItem.ToString())
                        {
                            folder = item;


                            break;
                        }
                    }
                    await folder.OpenAsync(FolderAccess.ReadWrite);


                    for (int i = folder.Count - 1; i >= 0; i--)
                    {
                        var m = await folder.GetMessageAsync(i);
                        string time = m.Date.DateTime.Day == DateTime.Now.Day ? m.Date.DateTime.ToShortTimeString() : m.Date.DateTime.ToShortDateString();
                        string? senred = m.From.Mailboxes.FirstOrDefault()?.Name == "" ? m.From.Mailboxes.FirstOrDefault()?.Address : m.From.Mailboxes.FirstOrDefault()?.Name;

                        model.AddProcess(new MyMessage(i, senred, m.Subject, time, m.From.Mailboxes.FirstOrDefault().Address));
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Search mail")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(username, password, ""));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(username, password);
                    foreach (var item in await client.GetFoldersAsync(client.PersonalNamespaces[0]))
                    {
                        if (model.folderName == folderList.SelectedItem.ToString())
                        {
                            folder = item;
                            break;
                        }
                    }
                    await folder.OpenAsync(FolderAccess.ReadWrite);
                    var ids = await folder.SearchAsync(SearchQuery.All);
                    if (ids.Count == 0)
                    {
                        MessageBox.Show("No messages to delete.");
                        return;
                    }
                    var id = ids[ids.Count - 1];
                    await folder.AddFlagsAsync(id, MessageFlags.Deleted, true);
                    await folder.ExpungeAsync();
                    model.ClearProcess();
                    GetMails();


                }

            }
            catch (Exception ex)
            { }
            //{ MessageBox.Show(ex.Message); }

            //await folder.ExpungeAsync();

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //IMailFolder folder;
            //foreach(var item in folderList.SelectedItems)
            //{
            //    var temp = item as IMailFolder;

            //    folder = temp;

            //}
            //int id = 0;
            //string name = mailList.SelectedItem.ToString();
            //for (var i = 0; i < mailList.Items.Count; i++)
            //{

            //    if(mailList.Items.Contains(name))
            //    {
            //        id = i; break;

            //    }
            //}
            //await folder.AddFlagsAsync(id, MessageFlags.Deleted, true);




        }

        private async void folderList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (folderList.SelectedItem != null)
                {


                    using (var client = new ImapClient())
                    {

                        await client.ConnectAsync("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
                        await client.AuthenticateAsync(username, password);


                        foreach (var item in await client.GetFoldersAsync(client.PersonalNamespaces[0]))
                        {
                            if (item.Name == folderList.SelectedItem.ToString())
                            {
                                folder = item;
                                model.folderName = item.Name;

                                break;
                            }
                        }

                        if (folder == null)
                        {
                            MessageBox.Show("Папку не знайдено!");
                            return;
                        }



                        folder.Open(FolderAccess.ReadWrite);
                        for (int i = folder.Count - 1; i >= 0; i--)
                        {
                            var m = await folder.GetMessageAsync(i);
                            string time = m.Date.DateTime.Day == DateTime.Now.Day ? m.Date.DateTime.ToShortTimeString() : m.Date.DateTime.ToShortDateString();
                            string? senred = m.From.Mailboxes.FirstOrDefault()?.Name == "" ? m.From.Mailboxes.FirstOrDefault()?.Address : m.From.Mailboxes.FirstOrDefault()?.Name;
                            if (i == folder.Count - 1)
                            {
                                model.ClearProcess();
                            }

                            model.AddProcess(new MyMessage(i, senred, m.Subject, time, m.From.Mailboxes.FirstOrDefault().Address));
                        }


                    }
                }

            }
            catch (Exception ex)
            { }

        }

        private void mailList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (mailList.SelectedItem != null)
            {
                foreach (var mail in mailList.SelectedItems)
                {
                    var folder = mail as MyMessage;

                    NavigationService.Navigate(new MainPage(username, password, folder.messageMail));
                }


            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Search mail";
                tb.Foreground = Brushes.Gray;
            }
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                model.ClearProcess();
                FilesTemp = model.Files.ToList();

                foreach (var item in FilesTemp)
                {
                    if (!string.IsNullOrEmpty(item.messagaSender) && item.messagaSender.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        model.AddProcess(item);
                    }

                }
                if (txtSearch.Text == "" || txtSearch.Text == null)
                {

                    model.AddProceses(FilesTemp);
                }

            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
            

        }


    }
    }
