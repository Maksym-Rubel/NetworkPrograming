using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using MailKit.Net.Imap;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace _09_DzSmtp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    /// 
    




    public partial class LoginPage : Page
    {
        string path = "users.json";
        List<LoginData> logins;
        public LoginPage()
        {
            InitializeComponent();
            //myImage.Source = new BitmapImage(new Uri("C:\\Users\\Maksym\\source\\repos\\NetworkPrograming\\09_DzSmtp\\09_DzSmtp\\bin\\Debug\\net8.0-windows\\Background.png"));
            myImage.Source = new BitmapImage(new Uri("pack://application:,,,/Background.png"));
            if (!File.Exists(path))
            {
                
                File.WriteAllText(path, "[]");
            }
            logins = GetLoginData();
            AddCombobox();
            //File.Create("users.json");

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Enter your mail address")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }

        }
        public void AddCombobox()
        {
            foreach (var login in logins)
            {
                CmBox.Items.Add(login.Email);
            }
            
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Enter your mail address";
                tb.Foreground = Brushes.Gray;
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Enter password")
            {
                tb.Text = "";
                tb.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Enter password";
                tb.Foreground = Brushes.Gray;
            }
        }
        public static string GetHash(string password)
        {
            using(var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(s => s.ToString("X2")));
            }
        }
        public List<LoginData> GetLoginData()
        {
            string text = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(text))
                return new List<LoginData>();
            return JsonSerializer.Deserialize<List<LoginData>>(text);
        }
        private async void LoginBtn(object sender, RoutedEventArgs e)
        {
            if (PassTxr.Text != "" && EmailTxt.Text != "")
            {
                try
                {
                    using (var client = new ImapClient())
                    {
                        await client.ConnectAsync("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
                        await client.AuthenticateAsync(EmailTxt.Text, PassTxr.Text);
                        if (client.IsAuthenticated == true)
                        {
                            NavigationService.Navigate(new MainMailPage(EmailTxt.Text, PassTxr.Text));
                            int counter = 0;
                            
                            if(logins.Count > 0)
                            {
                                foreach (var login in logins)
                                {
                                    if (EmailTxt.Text == login.Email)
                                    {
                                        counter++;
                                    }
                                }
                            }
                           
                            if(counter == 0)
                            {
                                var user = new LoginData
                                {
                                    Email = EmailTxt.Text,
                                    Password = PassTxr.Text
                                };
                                logins.Add(user);
                                    
                                
                                
                            }
                            
                            string json = JsonSerializer.Serialize(logins, new JsonSerializerOptions { WriteIndented = true});

                            File.WriteAllText(path, json);
                        }
                    }
                }
                catch (Exception ex) 
                { Console.WriteLine(ex); }


            }
           
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
    }
}
