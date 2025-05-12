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
using System.Windows.Shapes;

namespace _09_DzSmtp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //myImage.Source = new BitmapImage(new Uri("C:\\Users\\Maksym\\source\\repos\\NetworkPrograming\\09_DzSmtp\\09_DzSmtp\\bin\\Debug\\net8.0-windows\\Background.png"));
            myImage.Source = new BitmapImage(new Uri("pack://application:,,,/Background.png"));

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

        private void LoginBtn(object sender, RoutedEventArgs e)
        {

            //using (var client = new ImapClient())
            //{
            //    await client.ConnectAsync("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
            //    if(await client.AuthenticateAsync(username, password))
            //    { 
            //    }

                





            //}
            //if (PassTxr.Text != "" && EmailTxt.Text != "")
            //{
                //MainWindow mainwindow = new MainWindow(EmailTxt.Text, PassTxr.Text);
                //mainwindow.Show();
                //this.Close();
                //var main = (MainWindow)Application.Current.MainWindow;
                //main.SetUserContent(new Dashbord());
            //}
        }
    }
}
