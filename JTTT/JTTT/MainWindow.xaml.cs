using System;
using System.Collections.Generic;
using System.IO;
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
using System.Diagnostics;
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
        
        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
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
            var PicBox = (CheckBox)this.FindName("Pic");

            var ErrorBlock = (TextBlock)this.FindName("error");

            string file_name = "log.txt"; // log name

            ErrorBlock.Text = "";
            ErrorBlock.Visibility = Visibility.Hidden;

            var MailCheck = new Check_Mail(KeyBox.Text, URLBox.Text, MailBox.Text);

           // MailCheck.Check();
            //MailCheck.Job();

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
                    message.Subject = "Key found!";

                    var body = new TextPart("plain")
                    {
                        Text = @"Hey YourName,

                        We found your key("+KeyBox.Text+") on site "+url+@"

                        Have nice day!

                        -- JTTT"
                    };

                    var multipart = new Multipart("mixed");
                    multipart.Add(body);
                    // multipart.Add(attachment);

                    Log file = new Log(KeyBox.Text, URLBox.Text, MailBox.Text);
                    file.Save(file_name);

                    bool? flag = PicBox.IsChecked;

                    if(flag == true)
                    {
                    
                        var web = new HtmlWeb();
                        var doc = web.Load(URLBox.Text);

                        var nodes = doc.DocumentNode.Descendants("img");

                        foreach (var i in nodes)
                        {
                            if (i.GetAttributeValue("alt", "").ToLower().Contains(KeyBox.Text.ToLower()))
                            {
                                string path = @"img.jpg";
                                using (var client2 = new WebClient())
                                {
                                    client.DownloadFile(i.GetAttributeValue("src", ""), path);
                                }

                                var attachment = new MimePart("image", "jpg")
                                {
                                    Content = new MimeContent(File.OpenRead(path), ContentEncoding.Default),
                                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                                    ContentTransferEncoding = ContentEncoding.Base64,
                                    FileName = System.IO.Path.GetFileName(path)
                                };

                                multipart.Add(attachment);

                                ErrorBlock.Text = "Found and send";
                                ErrorBlock.Visibility = Visibility.Visible;
                                break;
                            }
                            else
                            {
                                ErrorBlock.Text = "Not found";
                                ErrorBlock.Visibility = Visibility.Visible;
                            }
                        }
                    }

                    // now set the multipart/mixed as the message body
                    message.Body = multipart;

                    using (var mailClient = new SmtpClient())
                    {
                        mailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        mailClient.Connect("scz.pl", 587, SecureSocketOptions.Auto);

                        mailClient.Authenticate(fromMailAdress, "Amadeusz");

                        mailClient.Send(message);
                        mailClient.Disconnect(true);
                    }

                }
                else
                {
                    ErrorBlock.Text = "Check Email";
                    ErrorBlock.Visibility = Visibility.Visible;

                    Log log = new Log(KeyBox.Text, URLBox.Text, "***Wrong URL: " + MailBox.Text);
                    log.Save(file_name);
                }

            }
            else
            {
                ErrorBlock.Text = "Check URL";
                ErrorBlock.Visibility = Visibility.Visible;

                Log log = new Log(KeyBox.Text, "***Wrong URL:  " + URLBox.Text,  MailBox.Text);
                log.Save(file_name);

            }

        }
    }
}
