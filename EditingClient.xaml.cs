using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для EditingClient.xaml
    /// </summary>
    public partial class EditingClient : Window
    {
        #region
        ViewTable View = new ViewTable();
        static public string ConnectionString = MainWindow.connectionString;
        #endregion
        public EditingClient()
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
        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            string count = ViewTable.ClientId;
            string UpdateQueryClient = $"Update Clients Set " +
                $"Name =N'{TextName.Text}'," +
                $"Surname =N'{TextFamile.Text}'," +
                $"Otchestvo =N'{TextDoubleName.Text}'," +
                $"Emall =N'{TextEmaill.Text}', " +
                $"Phone =N'{TextNumberPhone.Text}', " +
                $"Adres =N'{TextAdres.Text}' ," +
                $"MailingAddress =N'{TextPostalAdres.Text}', " +
                $"INNandKPP =N'{TextINNAndKPP.Text}', " +
                $"PaymentAccount =N'{TextPaymentAccount.Text}', " +
                $"Bank =N'{TextBank.Text}' ," +
                $"CorrespondentAccount =N'{TextCorrespondentAccount.Text}', " +
                $"BIC =N'{TextBIC.Text}' ," +
                $"MsPassport =N'{TextMS.Text}' " +
                $"where ClientId =N'{Convert.ToInt32(count)}' ";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(UpdateQueryClient, connection))
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Данные были обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка обновления данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                View.Show();
                this.Close();
            }
            View.Show();
            this.Close();
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            View.Show();
            this.Close();
        }
        private void FormLoad(object sender, RoutedEventArgs e)
        {
            TextFamile.Text = ViewTable.Famile;
            TextName.Text = ViewTable.NameClienta;
            TextDoubleName.Text = ViewTable.Otchestvo;
            TextEmaill.Text = ViewTable.Emall;
            TextNumberPhone.Text = ViewTable.Phone;
            TextAdres.Text = ViewTable.Adres;
            TextPostalAdres.Text = ViewTable.indexPostal;
            TextINNAndKPP.Text = ViewTable.INNandKPP;
            TextPaymentAccount.Text = ViewTable.PaymentAccount;
            TextBank.Text = ViewTable.Bank;
            TextCorrespondentAccount.Text = ViewTable.Correspondentaccount;
            TextBIC.Text = ViewTable.Bic;
            TextMS.Text = ViewTable.MSPasport;
        }
    }
}
