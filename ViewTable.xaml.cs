using Kursach.Classes;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для ViewTable.xaml
    /// </summary>
    public partial class ViewTable : Window
    {
        #region
        readonly DateClass Bd = new DateClass();
        static public string connectionString = MainWindow.connectionString;
        static public string QueryClient = "select Name as Имя,Surname as Фамилия,Otchestvo as Отчество,MsPassport as [МС Паспорта],Phone as Телефон" +
            ",Adres as Адрес, Emall as [Электронная почта], MailingAddress as [Почтовый адрес], Bank as [Банк], PaymentAccount " +
            "as [Расчетный счет] , INNandKPP as [ИНН\\КПП], CorrespondentAccount as [Корреспондентский счет],BIC as БИК from Clients";
        static public string QueryContarct = "select KeyId as [№], Clients.Surname as Клиент,Insurance_agent.Surname as Агент,TypeOfInsuranceName as [Вид страхования]," +
                   "cast(DateConclusions as date)as [Дата заключения контракта],cast(ExpiryDate as date) as [Дата окончания контракта],InsuranceSum as [Страховая сумма]," +
                   "TheRatioOfInsurance as [Процентная ставка %], CAST(InsuranceSum*TheRatioOfInsurance as numeric(17, 2)) as [Страхавая выплата]," +
                   "CAST(InsuranceSum*TheRatioOfInsurance/100 as numeric(17, 2)) as [Премия агента] from contract" +
                   " join Clients  on contract.ClientId = Clients.ClientId" +
                   " join Insurance on contract.TypeOfInsurance = Insurance.TypeOfInsurance" +
                   " join Insurance_agent on contract.AgentId = Insurance_agent.AgentId ";
        #endregion
        public ViewTable()
        {
            InitializeComponent();
        }
        private void TextChangedSerahClient(object sender, EventArgs e)
        {
            string QuerySearchClients = $"select Name as Имя,Surname as Фамилия,Otchestvo as Отчество,MsPassport as [МС Паспорта]," +
                $"Phone as Телефон,Adres as Адрес, Emall as [Электронная почта], MailingAddress as [Почтовый адрес], Bank as [Банк], " +
                $"PaymentAccount as [Расчетный счет] , INNandKPP as [ИНН\\КПП], CorrespondentAccount as [Корреспондентский счет]," +
                $"BIC as БИК from Clients where Surname like N'{TextSearchClient.Text}%' or MsPassport like '{TextSearchClient.Text}%'" +
                $" or Name like N'{TextSearchClient.Text}%' or Otchestvo like N'{TextSearchClient.Text}%'" +
                $" or Phone like N'{TextSearchClient.Text}%' or Adres like N'{TextSearchClient.Text}%'" +
                $" or Emall like N'{TextSearchClient.Text}%' or MailingAddress like N'{TextSearchClient.Text}%' " +
                $" or Bank like N'{TextSearchClient.Text}%'  or PaymentAccount like N'{TextSearchClient.Text}%'" +
                $" or INNandKPP like N'{TextSearchClient.Text}%' or CorrespondentAccount like N'{TextSearchClient.Text}%'" +
                $" or BIC like N'{TextSearchClient.Text}%'";
            try
            {
                TableClient.ItemsSource = Bd.InitializeGrid(connectionString, QuerySearchClients).DefaultView;
            }
            catch
            {

            }
        }
        private void TextChangedSerahContract(object sender, EventArgs e)
        {
            string QuerySearchContract = "select Clients.Surname as Клиент,Insurance_agent.Surname as Агент," +
                "TypeOfInsuranceName as [Вид страхования], DateConclusions as [Дата заключения контракта]," +
                "ExpiryDate as [Дата окончания контракта],InsuranceSum as [Страховая сумма]," +
                  "TheRatioOfInsurance as [Процентная ставка %], InsuranceSum* TheRatioOfInsurance as [Страхавая выплата]," +
                  $"CAST(InsuranceSum * TheRatioOfInsurance / 100 as numeric(17, 2)) as [Премия агента] " +
                  $"from contract join Clients on contract.ClientId = Clients.ClientId" +
                  $" join Insurance on contract.TypeOfInsurance = Insurance.TypeOfInsurance" +
                  $" join Insurance_agent on contract.AgentId = Insurance_agent.AgentId " +
                  $"where DateConclusions like N'{TextSearchContract.Text}%' or InsuranceSum like N'{TextSearchContract.Text}%' " +
                  $"or TypeOfInsuranceName like N'{TextSearchContract.Text}%' or Insurance_agent.Surname like N'{TextSearchContract.Text}%'" +
                  $" or Clients.Surname like N'{TextSearchContract.Text}%'or ExpiryDate like N'{TextSearchContract.Text}%' or KeyId like N'{TextSearchContract.Text}'";
            try
            {
                TableInsurance.ItemsSource = Bd.InitializeGrid(connectionString, QuerySearchContract).DefaultView;
            }
            catch
            {

            }
        }
        private void ClearClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TextSearchContract.Text = "Найти...";
                TextSearchClient.Text = "Найти...";
                TableClient.ItemsSource = Bd.InitializeGrid(connectionString, QueryClient).DefaultView;
                TableInsurance.ItemsSource = Bd.InitializeGrid(connectionString, QueryContarct).DefaultView;

            }
            catch
            {

            }
        }
        private void DataGrid_AutoGeneratedColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Дата заключения контракта")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            if (e.PropertyName == "Дата окончания контракта")
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }
        private void FormLoad(object sender, RoutedEventArgs e)
        {
            TableClient.ItemsSource = Bd.InitializeGrid(connectionString, QueryClient).DefaultView;
            TableInsurance.ItemsSource = Bd.InitializeGrid(connectionString, QueryContarct).DefaultView;
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                ViewFrom.Height = 450;
                ViewFrom.Width = 837.5;
            }
        }
        private void MenuClickExit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void MenuClickHelp(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\help123.chm");
        }
        private void ClickContMenuAddClient(object sender, RoutedEventArgs e)
        {
            AddClient OpenSetting = new AddClient();
            OpenSetting.Show();
            this.Close();
        }
        private void MenuClickVieaReport(object sender, RoutedEventArgs e)
        {
            VieaReport OpenVieaReport = new VieaReport();
            OpenVieaReport.Show();
            this.Close();
        }
        private void ClickContMenuInsurance(object sender, RoutedEventArgs e)
        {
            Insurance OpenSetting = new Insurance();
            OpenSetting.Show();
            this.Close();
        }
        private void ClickDeleteClient(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowView = TableClient.SelectedValue as DataRowView;
                string rowName = rowView[0].ToString();
                string rowFamile = rowView[1].ToString();
                string rowSurname = rowView[2].ToString();
                string rowMSPasport = rowView[3].ToString();
                string SQLDelete = $"DELETE FROM Clients WHERE Name = N'{rowName}' or Surname = N'{rowFamile}' or Otchestvo = N'{rowSurname}' or MsPassport = N'{rowMSPasport}'";
                Bd.Delete(connectionString, SQLDelete);
                TableClient.ItemsSource = Bd.InitializeGrid(connectionString, QueryClient).DefaultView;
                TableInsurance.ItemsSource = Bd.InitializeGrid(connectionString, QueryContarct).DefaultView;
            }
            catch
            {
                MessageBox.Show("Не выбрана запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClickDeleteContract(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowView = TableInsurance.CurrentItem as DataRowView;
                string row = rowView[0].ToString();
                string SQLDelete = $"DELETE FROM contract WHERE KeyId = {row}";
                Bd.Delete(connectionString, SQLDelete);
                TableInsurance.ItemsSource = Bd.InitializeGrid(connectionString, QueryContarct).DefaultView;
            }
            catch
            {
                MessageBox.Show("Не выбрана запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static string Famile, Surname, NameClienta, Otchestvo, Phone, Adres, Emall, ClientId
       , Bic, INNandKPP, PaymentAccount, Bank, Correspondentaccount, MSPasport, indexPostal;
        private void ClickEditingClient(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowView = TableClient.SelectedValue as DataRowView;
                NameClienta = rowView[0].ToString();
                Famile = rowView[1].ToString();
                Otchestvo = rowView[2].ToString();
                MSPasport = rowView[3].ToString();
                Phone = rowView[4].ToString();
                Adres = rowView[5].ToString();
                Emall = rowView[6].ToString();
                indexPostal = rowView[7].ToString();
                Bank = rowView[8].ToString();
                PaymentAccount = rowView[9].ToString();
                INNandKPP = rowView[10].ToString();
                Correspondentaccount = rowView[11].ToString();
                Bic = rowView[12].ToString();
                ClientId = Bd.ReturnValues(connectionString, "SELECT ClientId FROM Clients where MsPassport like", MSPasport);
                EditingClient EditingClient = new EditingClient();
                EditingClient.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не выбрана запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
