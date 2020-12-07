using Kursach.Classes;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        #region
        ViewTable View = new ViewTable();
        static public string ConnectionString = MainWindow.connectionString;
        #endregion

        public AddClient()
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
            try
            {
                if (String.IsNullOrEmpty(TextFamile.Text) && String.IsNullOrEmpty(TextName.Text) && String.IsNullOrEmpty(TextDoubleName.Text)
                && String.IsNullOrEmpty(TextAdres.Text) && String.IsNullOrEmpty(TextPostalAdres.Text) && String.IsNullOrEmpty(TextMS.Text)
                       && String.IsNullOrEmpty(TextNumberPhone.Text) && String.IsNullOrEmpty(TextEmaill.Text)
                       && String.IsNullOrEmpty(TextBank.Text) && String.IsNullOrEmpty(TextPaymentAccount.Text) && String.IsNullOrEmpty(TextINNAndKPP.Text)
                       && String.IsNullOrEmpty(TextBIC.Text) && String.IsNullOrEmpty(TextCorrespondentAccount.Text))
                {
                    MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = $"insert Clients (Surname,Name,Otchestvo,Emall,Phone,Adres,MailingAddress,INNandKPP,PaymentAccount,Bank,CorrespondentAccount,BIC,MsPassport)" +
                        $" values " +
                        $"(N'{TextFamile.Text}',N'{TextName.Text}',N'{TextDoubleName.Text}',N'{TextEmaill.Text}',N'{TextNumberPhone.Text}',N'{TextAdres.Text}',N'{TextPostalAdres.Text}',N'{TextINNAndKPP.Text}',N'{TextPaymentAccount.Text}',N'{TextBank.Text}',{TextCorrespondentAccount.Text},N'{TextBIC.Text}',N'{TextMS.Text}')";
                    DateClass Add = new DateClass();
                    Add.NewAdd(ConnectionString, query);
                    Close();

                    View.Show();
                }
            }
            catch
            {

            }
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            View.Show();
            this.Close();
        }
    }
}
