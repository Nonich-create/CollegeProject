using Kursach.Classes;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;



namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region
   
        static string TempLateFileName = (Application.StartupPath + "\\Insurance.mdf");
        static public string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={TempLateFileName};Integrated Security=True;Connect Timeout=30";


        readonly DateClass Bd = new DateClass();
        readonly string QueryAgentCombiBox = "select * from Insurance_agent order by Surname";
        Agents<string> agent = new Agents<string> { };
        #endregion
        public MainWindow()
        {
            InitializeComponent();
 
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                EntryForm.Height = 310;
                EntryForm.Width = 266;
            }
        }

        private void ButtonClickSetting(object sender, RoutedEventArgs e)
        {
            Setting OpenSetting = new Setting();
            OpenSetting.Show();
            this.Close();
        }
        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void ButtonClickRegistration(object sender, RoutedEventArgs e)
        {
            Registration OpenRegistration = new Registration();
            OpenRegistration.Show();
            this.Close();
        }
        private void FormLoad(object sender, RoutedEventArgs e)
        {
           
            Bd.AddCombobox(connectionString, QueryAgentCombiBox, AgentList, 1);
            agent.Agent = AgentList.Text;
        }
        private void ButtonClickEntrance(object sender, RoutedEventArgs e)
        {
            if (AgentList.Text == "")
            {
                MessageBox.Show("Выберите себя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XDocument xdocNew = new XDocument(new XElement("setting",
                    new XElement("Agents",
                    new XAttribute("Agent", AgentList.Text)
                    )));
                xdocNew.Save("setting.xml");
                agent.Agent = AgentList.Text;
                this.Hide();
                ViewTable OpenSetting = new ViewTable();
                OpenSetting.Show();
                this.Close();
            }
        }
    }
}
