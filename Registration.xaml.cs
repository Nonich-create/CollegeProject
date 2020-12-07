using Kursach.Classes;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MainWindow main = new MainWindow();
        public Registration()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                EntryForm.Height = 400;
                EntryForm.Width = 300;
            }
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            main.Show();
            this.Close();
        }
        private void ButtonClickRegistration(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextFamile.Text) && String.IsNullOrEmpty(TextName.Text)
                && String.IsNullOrEmpty(TextDoubleName.Text) && String.IsNullOrEmpty(TextEmail.Text)
                && String.IsNullOrEmpty(TextNumber.Text))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = $"insert Insurance_agent (Surname,Name,Otchestvo,Emall,Phone) values (N'{TextFamile.Text}',N'{TextName.Text}',N'{TextDoubleName.Text}',N'{TextEmail.Text}',N'{TextNumber.Text}')";
                DateClass Add = new DateClass();
                Add.NewAdd(MainWindow.connectionString, query);
                main.Show();
                this.Close();
            }
        }
        Function text = new Function();
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            text.TextClear(TextFamile, "Фамилия");
            text.TextClear(TextName, "Имя");
            text.TextClear(TextDoubleName, "Отчество");
            text.TextClear(TextEmail, "E-mail");
            text.TextClear(TextNumber, "Номер мобильного");
        }

    }
}
