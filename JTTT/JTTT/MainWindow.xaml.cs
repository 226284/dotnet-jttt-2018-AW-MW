﻿using System;
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

        private Dispatcher Dispatcher;
        private ListofTasks ListofTasks;

        private List<Action> ListofActions;
        private List<Condition> ListofConditions;

        private TextBox URLBox;
        private TextBox KeyBox;
        private TextBox MailBox;

        private TextBlock ErrorBlock;

        //private ComboBox ActionsComboBox;

        private ListBox TaskBox;

        private CheckBox PicBox;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
             URLBox = (TextBox)this.FindName("URL");
             KeyBox = (TextBox)this.FindName("Key");
             MailBox = (TextBox)this.FindName("Mail");

             ErrorBlock = (TextBlock)this.FindName("error");

             PicBox = (CheckBox)this.FindName("Pic");

             TaskBox = (ListBox)this.FindName("TaskListBox");

            ListofConditions = new List<Condition>();
            ListofActions = new List<Action>();

            /* Add all conditions */
            ListofConditions.Add(new Condition_img(new JTTT.Key(), new Url("")));

            /* Add all actions */
            ListofActions.Add(new Action_img(new JTTT.Mail()));

            ConditionsComboBox.ItemsSource = ListofConditions;
            ActionsComboBox.ItemsSource = ListofActions;

            ListofTasks = new ListofTasks();
            Dispatcher = new Dispatcher();


            foreach (Task t in ListofTasks.All())
            {
                TaskBox.Items.Add(t);
            }
        }
        
        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
        {
            
        }
        

        private void Add_Click(object sender, RoutedEventArgs ev)
        {
            var Log = new Log("","","");
            var Task = new Task(ActionsComboBox.SelectedItem as Action, ConditionsComboBox.SelectedItem as Condition, Log);

            ListofTasks.Add(Task);
            TaskBox.Items.Add(Task);
            TaskBox.Items.Refresh();

            

            

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Run();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ListofTasks.Clear();
            TaskBox.Items.Clear();
            TaskBox.Items.Refresh();
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {

        }



        private void smieci()
        {
            string file_name = "log.txt"; // log name

            ErrorBlock.Text = "";
            ErrorBlock.Visibility = Visibility.Hidden;

            if (Uri.IsWellFormedUriString(URLBox.Text, UriKind.Absolute))
            {
                url = URLBox.Text;

                WebClient client = new WebClient();
                reply = client.DownloadString(url);

                if (true)//IsValidEmail(MailBox.Text))
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

                        We found your key(" + KeyBox.Text + ") on site " + url + @"

                        Have nice day!

                        -- JTTT"
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

                    Log file = new Log(KeyBox.Text, URLBox.Text, MailBox.Text);
                    file.Save(file_name);

                    bool? flag = PicBox.IsChecked;

                    if (flag == true)
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
                                    Content = new MimeContent(System.IO.File.OpenRead(path), ContentEncoding.Default),
                                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                                    ContentTransferEncoding = ContentEncoding.Base64,
                                    FileName = System.IO.Path.GetFileName(path)
                                };

                                multipart.Add(attachment);

                                ErrorBlock.Text += "Found and send";
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

                        ////Note: only needed if the SMTP server requires authentication
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

                Log log = new Log(KeyBox.Text, "***Wrong URL:  " + URLBox.Text, MailBox.Text);
                log.Save(file_name);

            }
        }
    }
}
