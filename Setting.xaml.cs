using Kursach.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        MainWindow main = new MainWindow();
        public Setting()
        {
            InitializeComponent();
        }
        private void FormLoad(object sender, RoutedEventArgs e)
        {
            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = TextAdres.Text,
                MailingAddress = TextPostalAdres.Text,
                PhoneFax = TextPhoneAndFacs.Text,
                INNAndKPP = TextINNAndKPP.Text,
                PaymentAccount = TextPaymentAccount.Text,
                Bank = TextBank.Text,
                CorrespondentAccount = TextCorrespondentAccount.Text,
                BIC = TextBIC.Text,
                EMALL = TextEmail.Text
            };

            
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                TextCompanyName.Text = x.Attribute("CompanyName").Value;
                TextAdres.Text = x.Element("LegalAddress").Value;
                TextPostalAdres.Text = x.Element("MailingAddress").Value;
                TextPhoneAndFacs.Text = x.Element("PhoneFax").Value;
                TextINNAndKPP.Text = x.Element("INNAndKPP").Value;
                TextPaymentAccount.Text = x.Element("PaymentAccount").Value;
                TextBank.Text = x.Element("Bank").Value;
                TextCorrespondentAccount.Text = x.Element("CorrespondentAccount").Value;
                TextBIC.Text = x.Element("BIC").Value;
                TextEmail.Text = x.Element("EMALL").Value;
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
                EntryForm.Height = 450;
                EntryForm.Width = 800;
            }
        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            main.Show();
            this.Close();
        }
        private void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TextCompanyName.Text) && String.IsNullOrEmpty(TextAdres.Text)
                && String.IsNullOrEmpty(TextPostalAdres.Text) && String.IsNullOrEmpty(TextPhoneAndFacs.Text)
                && String.IsNullOrEmpty(TextINNAndKPP.Text) && String.IsNullOrEmpty(TextPaymentAccount.Text)
                && String.IsNullOrEmpty(TextPaymentAccount.Text) && String.IsNullOrEmpty(TextBank.Text)
                && String.IsNullOrEmpty(TextCorrespondentAccount.Text) && String.IsNullOrEmpty(TextBIC.Text)
                && String.IsNullOrEmpty(TextEmail.Text))
            {
                MessageBox.Show("Выберите себя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XDocument xdocNew = new XDocument(new XElement("settingCompany",
                    new XElement("Company",
                    new XAttribute("CompanyName", $"{TextCompanyName.Text}"),
                    new XElement("LegalAddress", TextAdres.Text),
                    new XElement("MailingAddress", TextPostalAdres.Text),
                    new XElement("PhoneFax", TextPhoneAndFacs.Text),
                    new XElement("INNAndKPP", TextINNAndKPP.Text),
                    new XElement("PaymentAccount", TextPaymentAccount.Text),
                    new XElement("Bank", TextBank.Text),
                    new XElement("CorrespondentAccount", TextCorrespondentAccount.Text),
                    new XElement("BIC", TextBIC.Text),
                    new XElement("EMALL", TextEmail.Text)
                    )));
                xdocNew.Save("settingCompany.xml");
                main.Show();
                this.Close();

            }
        }
        Function text = new Function();
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            text.TextClear(TextAdres, "Юридический адрес");
            text.TextClear(TextPostalAdres, "Почтовый адрес");
            text.TextClear(TextPhoneAndFacs, "Телефон/факс");
            text.TextClear(TextINNAndKPP, "ИНН/КПП");
            text.TextClear(TextPaymentAccount, "Расчетный счет");
            text.TextClear(TextBank, "Банк");
            text.TextClear(TextCorrespondentAccount, "Корреспондентский счет");
            text.TextClear(TextBIC, "БИК");
            text.TextClear(TextEmail, "E-Mail");
            text.TextClear(TextCompanyName, "Название компание");


        }
    }
}