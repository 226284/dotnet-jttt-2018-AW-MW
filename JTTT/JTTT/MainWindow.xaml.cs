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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace JTTT
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url;
        private string reply;

        private string fromMail = "JTTT";
        private string fromMailAdress = "amadi@scz.pl";

        private string toMailAdress;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }


        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs ev)
        {
            
            var URLBox = (TextBox)this.FindName("URL");
            var KeyBox = (TextBox)this.FindName("Key");
            var MailBox = (TextBox)this.FindName("Mail");

            var ErrorBlock = (TextBlock)this.FindName("error");

            ErrorBlock.Text = "";
            ErrorBlock.Visibility = Visibility.Hidden;

            if (Uri.IsWellFormedUriString(URLBox.Text, UriKind.Absolute))
            {
                url = URLBox.Text;

                WebClient client = new WebClient();
                reply = client.DownloadString(url);

                if (IsValidEmail(MailBox.Text))
                {
                    toMailAdress = MailBox.Text;

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(fromMail, fromMailAdress));
                    message.To.Add(new MailboxAddress("YourName", toMailAdress));
                    message.Subject = "Key found event!";

                    // create our message text, just like before (except don't set it as the message.Body)
                    var body = new TextPart("plain")
                    {
                        Text = @"Hey YourName,

We found your key("+KeyBox.Text+") on site "+url+@"

Have nice day!

-- JTTT
"
                    };

                    // create an image attachment for the file located at path
                   /* var attachment = new MimePart("image", "gif")
                    {
                        Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(path)
                    };*/

                    // now create the multipart/mixed container to hold the message text and the
                    // image attachment
                    var multipart = new Multipart("mixed");
                    multipart.Add(body);
                   // multipart.Add(attachment);

                    // now set the multipart/mixed as the message body
                    message.Body = multipart;

                    using (var mailClient = new SmtpClient())
                    {
                        mailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        mailClient.Connect("scz.pl", 587, SecureSocketOptions.Auto);

                        ////Note: only needed if the SMTP server requires authentication
                        mailClient.Authenticate(fromMailAdress, "Amadeusz");

                        mailClient.Send(message);
                        mailClient.Disconnect(true);
                    }

                } else
                {
                    ErrorBlock.Text = "Check Email";
                    ErrorBlock.Visibility = Visibility.Visible;
                }

            }
            else
            {
                ErrorBlock.Text = "Check URL";
                ErrorBlock.Visibility = Visibility.Visible;
            }

        }
    }
}
