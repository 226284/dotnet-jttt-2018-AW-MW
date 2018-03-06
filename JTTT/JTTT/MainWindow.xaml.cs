using System;
using System.Collections.Generic;
using System.Linq;
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
using HtmlAgilityPack;

namespace JTTT
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url;
        private string reply;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var URLBox = (TextBox)this.FindName("URL");
            var KeyBox = (TextBox)this.FindName("Key");

            var ErrorBlock = (TextBlock)this.FindName("error");

            ErrorBlock.Text = "";
            ErrorBlock.Visibility = Visibility.Hidden;

            if (Uri.IsWellFormedUriString(URLBox.Text, UriKind.Absolute))
            {
                url = URLBox.Text;

                WebClient client = new WebClient();
                reply = client.DownloadString(url);
            }
            else
            {
                ErrorBlock.Text = "Check URL";
                ErrorBlock.Visibility = Visibility.Visible;
            }

        }
    }
}
