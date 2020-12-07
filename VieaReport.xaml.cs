    using Kursach.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для VieaReport.xaml
    /// </summary>
    public partial class VieaReport : System.Windows.Window
    {
        #region
        readonly ViewTable View = new ViewTable();
        readonly DateClass Bd = new DateClass();
        static public string connectionString = MainWindow.connectionString;
        public System.Data.DataTable Table = new System.Data.DataTable();

        #endregion
        public VieaReport()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                ViewFrom.Height = 450;
                ViewFrom.Width = 800;
            }
        }
        private void ButtonClickHidePrintReport(object sender, RoutedEventArgs e)
        {
            View.Show();
            this.Close();
        }
        private void ButtonClickPrintReport(object sender, RoutedEventArgs e)
        {
            try
            {
                View.Show();
                TableVieaReport.Visibility = Visibility.Hidden;
                PrintList.Visibility = Visibility.Visible;
                PrintDialog printDlg = new PrintDialog();
                printDlg.PrintVisual(PrintList, "печать.");
                this.Close();
            }
            catch
            {

            }
        }

        private int Mount(string Mount)
        {
            if (Mount == "январь")
            {
                return 1;
            }
            else
            if (Mount == "февраль")
            {
                return 2;
            }
            else
            if (Mount == "март")
            {
                return 3;
            }
            else
            if (Mount == "апрель")
            {
                return 4;
            }
            else
            if (Mount == "май")
            {
                return 5;
            }
            else
            if (Mount == "июнь")
            {
                return 6;
            }
            else
            if (Mount == "июль")
            {
                return 7;
            }
            else
            if (Mount == "август")
            {
                return 8;
            }
            else
            if (Mount == "сентябрь")
            {
                return 9;
            }
            else
            if (Mount == "октябрь")
            {
                return 10;
            }
            else
            if (Mount == "ноябрь")
            {
                return 11;
            }
            else
            if (Mount == "декабрь")
            {
                return 12;
            }
            return 0;
        }
        private void SelectIncome()
        {
            try
            {
                if (MonthList.Text != "за год")
                {
                    string query = $"select Surname as Фамилия,Name as Имя,Otchestvo as Отчество , CAST(sum(InsuranceSum*TheRatioOfInsurance/100) as numeric(17, 2)) as [Премии за месяц] from contract join insurance_agent on contract.AgentId = Insurance_agent.AgentId  where   " +
                  $"  MONTH(DateConclusions) = {Mount(MonthList.Text)} and Year(DateConclusions) = {TextYear.Text}  GROUP BY Surname,Name,Otchestvo";
                    TableVieaReport.ItemsSource = Bd.InitializeGrid(connectionString, query).DefaultView;
                    PrintTable.ItemsSource = Bd.InitializeGrid(connectionString, query).DefaultView;
                    labelDate.Content = $"за {MonthList.Text} {TextYear.Text}";
                }
                else
                {
                    string query = $"select Surname as Фамилия,Name as Имя,Otchestvo as Отчество , CAST(sum(InsuranceSum*TheRatioOfInsurance/100) as numeric(17, 2)) as [Премии за год] from contract join insurance_agent on contract.AgentId = Insurance_agent.AgentId  where   " +
                 $"Year(DateConclusions) = {TextYear.Text}  GROUP BY Surname,Name,Otchestvo";
                    TableVieaReport.ItemsSource = Bd.InitializeGrid(connectionString, query).DefaultView;
                    PrintTable.ItemsSource = Bd.InitializeGrid(connectionString, query).DefaultView;
                    labelDate.Content = $"за год {TextYear.Text}";
                }
            }
            catch
            {

            }
        }

        private void TextChangedList(object sender, EventArgs e)
        {
            SelectIncome();
        }
        private void TextChangedYear(object sender, EventArgs e)
        {
            DateTime CurrentMonth;
            CurrentMonth = DateTime.Now;
            if (String.IsNullOrEmpty(TextYear.Text))
            {
                TextYear.Text = CurrentMonth.ToString("yyyy");
            }
            SelectIncome();
        }

    }
}
