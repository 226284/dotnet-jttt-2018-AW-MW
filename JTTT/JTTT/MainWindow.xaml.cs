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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        private ListofTask ListofTask;

        private List<Action> ListofActions;
        private List<Condition> ListofConditions;

        private TextBox URLBox;
        private TextBox KeyBox;
        private TextBox MailBox;

        private TextBlock ErrorBlock;

        //private ComboBox ActionsComboBox;

        private ListBox TaskBox;

        private CheckBox PicBox;

        private File file;

        private UrlValidator urlValidator;
        private MailValidator mailValidator;

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
            ListofConditions.Add(new Condition_img(new JTTT.Key(""), new Url("")));

            /* Add all actions */
            ListofActions.Add(new Action_img(new JTTT.Mail("")));

            ConditionsComboBox.ItemsSource = ListofConditions;
            ActionsComboBox.ItemsSource = ListofActions;

            ListofTask = new ListofTask();


            foreach (Task t in ListofTask.All())
            {
                TaskBox.Items.Add(t);
            }

            file = new File("jttt.log");

            urlValidator = new UrlValidator();
            mailValidator = new MailValidator();

            /*przywracanie tasków z bazy danynch*/
            using (var db = new JTTTDbContext())
            {
                Task tmp = new Task();
                // pomocniczy task
                
                foreach (var l in db.ListofTasks)
                {
                    foreach (var t in l.Tasks)
                    {
                        
                        tmp.Action.Mail = t.Action.Mail;
                        /*tmp.Condition.Url = t.Condition.Url;
                        tmp.Condition.Key = t.Condition.Key;
                        tmp.Time = t.Time;

                        TaskBox.Items.Add(tmp);
                        TaskBox.Items.Refresh();
                        */
                    }
                }
                
            }
        }

        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
        {

        }


        private void Add_Click(object sender, RoutedEventArgs ev)
        {
            var C = ConditionsComboBox.SelectedItem as Condition;
            var A = ActionsComboBox.SelectedItem as Action;

            C.Key = new Key(KeyBox.Text);
            C.Url = new Url(URLBox.Text);
            A.Mail = new Mail(MailBox.Text);

            //var Task = new Task(A, C, new Time()); //{ Name = "Przykładowa nazwa" }; - bez db
            var Task = new Task();
            Task.Action = A;
            Task.Condition = C;
            Task.Time = new Time();


            Log Log = new Log(Task);

            if (urlValidator.isValid(C.Url) && mailValidator.isValid(A.Mail))
            {
                ListofTask.Add(Task);
                TaskBox.Items.Add(Task);
                TaskBox.Items.Refresh();
            }

            /* dodawanie tasków do bazy danych*/
            using (var db = new JTTTDbContext())
            {
                db.ListofTasks.Add(ListofTask); //err: wartość nie może być zerowa
                db.SaveChanges();
            }

        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher = new Dispatcher(ListofTask);
            Dispatcher.Run();

            // TUTAJ ZNAJDUJE SIĘ TESTOWANIE MSSQL ****************************************************************
            /*
            using (var db = new JTTTDbContext())
            {
                var list = new ListofTask() { Name = "Długa lista", Id = 1 };
                var task = new Task(new Action_img(new JTTT.Mail("jhjkh")), new Condition_img(new JTTT.Key("d"), new Url("d")), new Time()) { Name = "First", Id = 1 };
                var task2 = new Task(new Action_img(new JTTT.Mail("jhkjkhj")), new Condition_img(new JTTT.Key("s"), new Url("s")), new Time()) { Name = "Second", Id = 2 };
                var task3 = new Task(new Action_img(new JTTT.Mail("jjjjjkhkj")), new Condition_img(new JTTT.Key("f"), new Url("f")), new Time()) { Name = "Third", Id = 3 };

                list.Tasks.Add(task);
                list.Tasks.Add(task2);
                list.Tasks.Add(task2);

                db.ListofTasks.Add(list); //err: wartość nie może być zerowa
                db.SaveChanges();
            }
            */
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ListofTask.Clear();
            TaskBox.Items.Clear();
            TaskBox.Items.Refresh();
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            Serialize Serialize = new Serialize();

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(file.Name))
            {
                sw.WriteLine(Serialize.JsonSerialize(ListofTask));
            }

            ListofTask.Clear();
            TaskBox.Items.Clear();
            TaskBox.Items.Refresh();
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            Deserialize Deserialize = new Deserialize();

            try
            {
                using (StreamReader sr = new StreamReader(file.Name))
                {
                    var text = sr.ReadLine();
                    ListofTask = Deserialize.JsonDeserialize(text);

                    foreach (Task t in ListofTask.All())
                    {
                        TaskBox.Items.Add(t);
                    }
                    TaskBox.Items.Refresh();
                }
            }

            catch
            {
                Console.WriteLine("You fucked up");
            }
        }
    }
}
