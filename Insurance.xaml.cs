using Kursach.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Insurance.xaml
    /// </summary>
    public partial class Insurance : Window
    {
        #region
        readonly string returnvalueClient = "SELECT ClientId FROM Clients where Surname like N";
        readonly string QueryInsuranceCombiBox = "select * from Insurance order by TypeOfInsuranceName";
        static public string connectionString = MainWindow.connectionString;
        readonly DateClass Bd = new DateClass();
        readonly string returnvalueAgent = "SELECT AgentId FROM Insurance_agent where Surname like N";
        readonly string returnvalueInsurance = "SELECT TypeOfInsurance FROM Insurance where TypeOfInsuranceName like N";
        readonly string QueryClientCombiBox = "select * from Clients order by Surname";
        readonly ViewTable View = new ViewTable();
        DateTime StartDate = new DateTime();
        DateTime EndDate = new DateTime();
        public string FullName, AdresClienta, Statement;
        #endregion
        public Insurance()
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
        private void FormLoad(object sender, RoutedEventArgs e)
        {
            StartDate = DateTime.Now;
            TextStartDate.Text = StartDate.ToShortDateString();
            EndDate = StartDate.AddYears(1);
            TextEndDate.Text = EndDate.ToShortDateString();
            Bd.AddCombobox(connectionString, QueryInsuranceCombiBox, InsuranceList, 1);
            Bd.AddCombobox(connectionString, QueryClientCombiBox, ClientList, 1);
            StreamReader read = new StreamReader("setting.xml");
            if (read.ReadToEnd().Trim().Length > 0)
            {
                XDocument xdocload = XDocument.Load("setting.xml");
                XElement root = xdocload.Element("setting");
                foreach (XElement x in root.Elements("Agents").ToList())
                {
                    TextAgent.Text = x.Attribute("Agent").Value;
                }
            }
        }
        private void ButtonClickAddInsurance(object sender, RoutedEventArgs e)
        {
            CaseInclude(InsuranceList.Text);
        }
        private void PrintLifeInsurance()
        {
            string
            Famile = Convert.ToString(ClientList.Text),
            contribution = Convert.ToString(TextViewInsuranceSum.Text),
            payment = Convert.ToString(TextInsuranceSumm.Text),
            StartDate = Convert.ToString(TextStartDate.Text),
            EndDate = Convert.ToString(TextEndDate.Text),
            Agent = Convert.ToString(TextAgent.Text),
            FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
            + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
            AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
            MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
            PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
            INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
            PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
            BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
            CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
            BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
            KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
            MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ";
            PrintDoc print = new PrintDoc();
            var complate =
                (
                 Agent: "",
                 CompanyName: "",
                 LegalAddress: "",
                 MailingAddress: "",
                 PhoneFax: "",
                 INNAndKPP: "",
                 PaymentAccount: "",
                 Bank: "",
                 CorrespondentAccount: "",
                 BIC: "",
                 EMALL: "",
                 StartDate: "",
                 EndDate: "",
                 payment: "",
                 contribution: "",
                 FullName: "",
                 AdresClienta: "",
                 MailingAddressClienta: "",
                 PhoneClienta: "",
                 INNandKPPClienta: "",
                 PaymentAccountClient: "",
                 BankClient: "",
                 CorrespondentAccountClienta: "",
                 BICClient: "",
                 KPPClienta: "",
                 MSPasport: ""
                 );
            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = complate.LegalAddress,
                MailingAddress = complate.MailingAddress,
                PhoneFax = complate.PhoneFax,
                INNAndKPP = complate.INNAndKPP,
                PaymentAccount = complate.PaymentAccount,
                Bank = complate.Bank,
                CorrespondentAccount = complate.CorrespondentAccount,
                BIC = complate.BIC,
                EMALL = complate.EMALL,
                CompanyName = complate.CompanyName
            };
            _ = new List<Insurer<string>> { insurer };
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                complate =
                (Agent,
                 CompanyName: x.Attribute("CompanyName").Value + " ",
                 LegalAddress: x.Element("LegalAddress").Value + " ",
                 MailingAddress: x.Element("MailingAddress").Value + " ",
                 PhoneFax: x.Element("PhoneFax").Value + " ",
                 INNAndKPP: x.Element("INNAndKPP").Value + " ",
                 PaymentAccount: x.Element("PaymentAccount").Value + " ",
                 Bank: x.Element("Bank").Value + " ",
                 CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                 BIC: x.Element("BIC").Value + " ",
                 EMALL: x.Element("EMALL").Value + " ",
                 StartDate,
                 EndDate,
                 payment,
                 contribution,
                 FullName,
                 AdresClienta,
                 MailingAddressClienta,
                 PhoneClienta,
                 INNandKPPClienta,
                 PaymentAccountClient,
                 BankClient,
                 CorrespondentAccountClienta,
                 BICClient,
                 KPPClienta,
                 MSPasport
                );
            }
            print.PrintDocument(
               complate.StartDate,
               complate.EndDate,
               complate.CompanyName,
               complate.Agent,
               complate.FullName,
               complate.contribution,
               complate.payment,
               complate.LegalAddress,
               complate.MailingAddress,
               complate.PhoneFax,
               complate.INNAndKPP,
               complate.PaymentAccount,
               complate.Bank,
               complate.CorrespondentAccount,
               complate.BIC,
               complate.AdresClienta,
               complate.MailingAddressClienta,
               complate.PhoneClienta,
               complate.BICClient,
               complate.PaymentAccountClient,
               complate.BankClient,
               complate.CorrespondentAccountClienta,
               complate.BICClient,
               complate.KPPClienta,
               complate.MSPasport
               );
        }
        private void PrintAnimalsByTransportation()
        {
            string
          Famile = Convert.ToString(ClientList.Text),
          contribution = Convert.ToString(TextViewInsuranceSum.Text),
          payment = Convert.ToString(TextInsuranceSumm.Text),
          StartDate = Convert.ToString(TextStartDate.Text),
          EndDate = Convert.ToString(TextEndDate.Text),
          Agent = Convert.ToString(TextAgent.Text),
          PlaceOfDeparture = Convert.ToString(PlaceDeparture.Text),
          TheirDestination = Convert.ToString(Destination.Text),
          AnimalsName = Convert.ToString(Nickname.Text),
          ModeOfTransport = Convert.ToString(Transport.Text),
          FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
          + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
          AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
          MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
          PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
          INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
          BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
          CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
          BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
          KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ";
            PrintDoc print = new PrintDoc();
            var complate =
                (
                 Agent: "",
                 CompanyName: "",
                 LegalAddress: "",
                 MailingAddress: "",
                 PhoneFax: "",
                 INNAndKPP: "",
                 PaymentAccount: "",
                 Bank: "",
                 CorrespondentAccount: "",
                 BIC: "",
                 EMALL: "",
                 StartDate: "",
                 EndDate: "",
                 payment: "",
                 contribution: "",
                 FullName: "",
                 AdresClienta: "",
                 MailingAddressClienta: "",
                 PhoneClienta: "",
                 INNandKPPClienta: "",
                 PaymentAccountClient: "",
                 BankClient: "",
                 CorrespondentAccountClienta: "",
                 BICClient: "",
                 KPPClienta: "",
                 PlaceOfDeparture: "",
                 TheirDestination: "",
                 AnimalsName: "",
                 ModeOfTransport: "",
                 MSPasport: ""
                 );

            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = complate.LegalAddress,
                MailingAddress = complate.MailingAddress,
                PhoneFax = complate.PhoneFax,
                INNAndKPP = complate.INNAndKPP,
                PaymentAccount = complate.PaymentAccount,
                Bank = complate.Bank,
                CorrespondentAccount = complate.CorrespondentAccount,
                BIC = complate.BIC,
                EMALL = complate.EMALL,
                CompanyName = complate.CompanyName
            };
            _ = new List<Insurer<string>> { insurer };
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                complate =
                (Agent,
                 CompanyName: x.Attribute("CompanyName").Value + " ",
                 LegalAddress: x.Element("LegalAddress").Value + " ",
                 MailingAddress: x.Element("MailingAddress").Value + " ",
                 PhoneFax: x.Element("PhoneFax").Value + " ",
                 INNAndKPP: x.Element("INNAndKPP").Value + " ",
                 PaymentAccount: x.Element("PaymentAccount").Value + " ",
                 Bank: x.Element("Bank").Value + " ",
                 CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                 BIC: x.Element("BIC").Value + " ",
                 EMALL: x.Element("EMALL").Value + " ",
                 StartDate,
                 EndDate,
                 payment,
                 contribution,
                 FullName,
                 AdresClienta,
                 MailingAddressClienta,
                 PhoneClienta,
                 INNandKPPClienta,
                 PaymentAccountClient,
                 BankClient,
                 CorrespondentAccountClienta,
                 BICClient,
                 KPPClienta,
                 PlaceOfDeparture,
                 TheirDestination,
                 AnimalsName,
                 ModeOfTransport,
                 MSPasport
                );
            }
            print.PrintDocument(
                complate.StartDate,
                complate.EndDate,
                complate.CompanyName,
                complate.Agent,
                complate.FullName,
                complate.contribution,
                complate.payment,
                complate.LegalAddress,
                complate.MailingAddress,
                complate.PhoneFax,
                complate.INNAndKPP,
                complate.PaymentAccount,
                complate.Bank,
                complate.CorrespondentAccount,
                complate.BIC,
                complate.AdresClienta,
                complate.MailingAddressClienta,
                complate.PhoneClienta,
                complate.BICClient,
                complate.PaymentAccountClient,
                complate.BankClient,
                complate.CorrespondentAccountClienta,
                complate.BICClient,
                complate.KPPClienta,
                complate.PlaceOfDeparture,
                complate.TheirDestination,
                complate.AnimalsName,
                complate.ModeOfTransport,
                complate.MSPasport
                );
        }
        private void PrintContractHomeInsurance()
        {
            string
          Famile = Convert.ToString(ClientList.Text),
          contribution = Convert.ToString(TextViewInsuranceSum.Text),
          payment = Convert.ToString(TextInsuranceSumm.Text),
          StartDate = Convert.ToString(TextStartDate.Text),
          EndDate = Convert.ToString(TextEndDate.Text),
          Agent = Convert.ToString(TextAgent.Text),
          FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
          + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
          AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
          MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
          PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
          INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
          BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
          CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
          BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
          KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ",
            Loanagreement = Convert.ToString(LoanAgreement.Text),
          Loanagreementnumber = Convert.ToString(LoanAgreementNumber.Text),
          adres = Convert.ToString(AdresHome.Text),
          room = Convert.ToString(Rooms.Text),
          S = Convert.ToString(TotalArea.Text),
          storey = Convert.ToString(FloorHome.Text),
          level = Convert.ToString(PlaceFloorHome.Text),
          number = Convert.ToString(NumberFlat.Text),
          DocumentOfTheRightToResidentialSpace = _ = new TextRange(DocumentoOfTheRightToResidentialSpace.Document.ContentStart, DocumentoOfTheRightToResidentialSpace.Document.ContentEnd).Text;
            PrintDoc print = new PrintDoc();
            var complate =
                (
                 Agent: "",
                 CompanyName: "",
                 LegalAddress: "",
                 MailingAddress: "",
                 PhoneFax: "",
                 INNAndKPP: "",
                 PaymentAccount: "",
                 Bank: "",
                 CorrespondentAccount: "",
                 BIC: "",
                 EMALL: "",
                 StartDate: "",
                 EndDate: "",
                 payment: "",
                 contribution: "",
                 FullName: "",
                 AdresClienta: "",
                 MailingAddressClienta: "",
                 PhoneClienta: "",
                 INNandKPPClienta: "",
                 PaymentAccountClient: "",
                 BankClient: "",
                 CorrespondentAccountClienta: "",
                 BICClient: "",
                 KPPClienta: "",
                 Loanagreement: "",
                 Loanagreementnumber: "",
                 adres: "",
                 room: "",
                 S: "",
                 storey: "",
                 level: "",
                 number: "",
                 DocumentOfTheRightToResidentialSpace: "",
                 MSPasport: ""
                 );
            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = complate.LegalAddress,
                MailingAddress = complate.MailingAddress,
                PhoneFax = complate.PhoneFax,
                INNAndKPP = complate.INNAndKPP,
                PaymentAccount = complate.PaymentAccount,
                Bank = complate.Bank,
                CorrespondentAccount = complate.CorrespondentAccount,
                BIC = complate.BIC,
                EMALL = complate.EMALL,
                CompanyName = complate.CompanyName
            };
            _ = new List<Insurer<string>> { insurer };
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                complate =
                (Agent,
                 CompanyName: x.Attribute("CompanyName").Value + " ",
                 LegalAddress: x.Element("LegalAddress").Value + " ",
                 MailingAddress: x.Element("MailingAddress").Value + " ",
                 PhoneFax: x.Element("PhoneFax").Value + " ",
                 INNAndKPP: x.Element("INNAndKPP").Value + " ",
                 PaymentAccount: x.Element("PaymentAccount").Value + " ",
                 Bank: x.Element("Bank").Value + " ",
                 CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                 BIC: x.Element("BIC").Value + " ",
                 EMALL: x.Element("EMALL").Value + " ",
                 StartDate,
                 EndDate,
                 payment,
                 contribution,
                 FullName,
                 AdresClienta,
                 MailingAddressClienta,
                 PhoneClienta,
                 INNandKPPClienta,
                 PaymentAccountClient,
                 BankClient,
                 CorrespondentAccountClienta,
                 BICClient,
                 KPPClienta,
                 Loanagreement,
                 Loanagreementnumber,
                 adres,
                 room,
                 S,
                 storey,
                 level,
                 number,
                 DocumentOfTheRightToResidentialSpace,
                 MSPasport
                );
            }
            print.PrintDocument(
                complate.StartDate,
                complate.EndDate,
                complate.CompanyName,
                complate.Agent,
                complate.FullName,
                complate.contribution,
                complate.payment,
                complate.LegalAddress,
                complate.MailingAddress,
                complate.PhoneFax,
                complate.INNAndKPP,
                complate.PaymentAccount,
                complate.Bank,
                complate.CorrespondentAccount,
                complate.BIC,
                complate.AdresClienta,
                complate.MailingAddressClienta,
                complate.PhoneClienta,
                complate.BICClient,
                complate.PaymentAccountClient,
                complate.BankClient,
                complate.CorrespondentAccountClienta,
                complate.BICClient,
                complate.KPPClienta,
                complate.Loanagreement,
                complate.Loanagreementnumber,
                complate.adres,
                complate.room,
                complate.S,
                complate.storey,
                complate.level,
                complate.number,
                complate.DocumentOfTheRightToResidentialSpace,
                complate.MSPasport
                );
        }
        private void PrintUniversalTreaty()
        {
            {
                string
                Famile = Convert.ToString(ClientList.Text),
                contribution = Convert.ToString(TextViewInsuranceSum.Text),
                payment = Convert.ToString(TextInsuranceSumm.Text),
                StartDate = Convert.ToString(TextStartDate.Text),
                EndDate = Convert.ToString(TextEndDate.Text),
                Agent = Convert.ToString(TextAgent.Text),
                FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
                + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
                AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
                MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
                PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
                INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
                PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
                BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
                CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
                BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
                KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
                MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ",
                UniversalTreaty = Convert.ToString(_ = new TextRange(NameInsurance.Document.ContentStart, NameInsurance.Document.ContentEnd).Text),
                InsuranceEventPrint = Convert.ToString(_ = new TextRange(InsuranceEvent.Document.ContentStart, InsuranceEvent.Document.ContentEnd).Text);
                PrintDoc print = new PrintDoc();
                var complate =
                    (
                     Agent: "",
                     CompanyName: "",
                     LegalAddress: "",
                     MailingAddress: "",
                     PhoneFax: "",
                     INNAndKPP: "",
                     PaymentAccount: "",
                     Bank: "",
                     CorrespondentAccount: "",
                     BIC: "",
                     EMALL: "",
                     StartDate: "",
                     EndDate: "",
                     payment: "",
                     contribution: "",
                     FullName: "",
                     AdresClienta: "",
                     MailingAddressClienta: "",
                     PhoneClienta: "",
                     INNandKPPClienta: "",
                     PaymentAccountClient: "",
                     BankClient: "",
                     CorrespondentAccountClienta: "",
                     BICClient: "",
                     KPPClienta: "",
                     UniversalTreaty: "",
                     InsuranceEventPrint: "",
                     MSPasport: ""
                     );
                Insurer<string> insurer = new Insurer<string>
                {
                    LegalAddress = complate.LegalAddress,
                    MailingAddress = complate.MailingAddress,
                    PhoneFax = complate.PhoneFax,
                    INNAndKPP = complate.INNAndKPP,
                    PaymentAccount = complate.PaymentAccount,
                    Bank = complate.Bank,
                    CorrespondentAccount = complate.CorrespondentAccount,
                    BIC = complate.BIC,
                    EMALL = complate.EMALL,
                    CompanyName = complate.CompanyName
                };
                _ = new List<Insurer<string>> { insurer };
                XDocument xdocload = XDocument.Load("settingCompany.xml");
                XElement root = xdocload.Element("settingCompany");
                foreach (XElement x in root.Elements("Company").ToList())
                {
                    complate =
                    (Agent,
                    CompanyName: x.Attribute("CompanyName").Value + " ",
                    LegalAddress: x.Element("LegalAddress").Value + " ",
                    MailingAddress: x.Element("MailingAddress").Value + " ",
                    PhoneFax: x.Element("PhoneFax").Value + " ",
                    INNAndKPP: x.Element("INNAndKPP").Value + " ",
                    PaymentAccount: x.Element("PaymentAccount").Value + " ",
                    Bank: x.Element("Bank").Value + " ",
                    CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                    BIC: x.Element("BIC").Value + " ",
                    EMALL: x.Element("EMALL").Value + " ",
                    StartDate,
                    EndDate,
                    payment,
                    contribution,
                    FullName,
                    AdresClienta,
                    MailingAddressClienta,
                    PhoneClienta,
                    INNandKPPClienta,
                    PaymentAccountClient,
                    BankClient,
                    CorrespondentAccountClienta,
                    BICClient,
                    KPPClienta,
                    UniversalTreaty,
                    InsuranceEventPrint,
                    MSPasport
                   );
                }
                print.PrintDocument(
                complate.StartDate,
                complate.EndDate,
                complate.CompanyName,
                complate.Agent,
                complate.FullName,
                complate.contribution,
                complate.payment,
                complate.LegalAddress,
                complate.MailingAddress,
                complate.PhoneFax,
                complate.INNAndKPP,
                complate.PaymentAccount,
                complate.Bank,
                complate.CorrespondentAccount,
                complate.BIC,
                complate.AdresClienta,
                complate.MailingAddressClienta,
                complate.PhoneClienta,
                complate.BICClient,
                complate.PaymentAccountClient,
                complate.BankClient,
                complate.CorrespondentAccountClienta,
                complate.BICClient,
                complate.KPPClienta,
                complate.UniversalTreaty,
                complate.InsuranceEventPrint,
                complate.MSPasport
                );
            }
        }
        private void PrintStatements()
        {
            _ =
               (
                Statement: "",
                Agent: "",
                StartDate: "",
                EndDate: "",
                payment: "",
                FullName: "",
                AdresClienta: ""
                );
            (string Statement, string Agent, string StartDate, string EndDate, string payment, string FullName, string AdresClienta) complate =
            (
             Statement,
             TextAgent.Text,
             StartDate.ToString(),
             EndDate.ToString(),
             TextInsuranceSumm.Text,
             FullName,
             AdresClienta
            );
            PrintDoc print = new PrintDoc();
            print.ReadyMadeApplications(
                   complate.Statement,
                   complate.StartDate,
                   complate.EndDate,
                   complate.Agent,
                   complate.FullName,
                   complate.payment,
                   complate.AdresClienta);
        }
        private void PrintAContractForPropertyInsurance()
        {
            string
            Famile = Convert.ToString(ClientList.Text),
            contribution = Convert.ToString(TextViewInsuranceSum.Text),
            payment = Convert.ToString(TextInsuranceSumm.Text),
            StartDate = Convert.ToString(TextStartDate.Text),
            EndDate = Convert.ToString(TextEndDate.Text),
            Agent = Convert.ToString(TextAgent.Text),
            FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
            + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
            AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
            MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
            PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
            INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
            PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
            BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
            CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
            BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
            KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
            MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ",
            objectType = Convert.ToString(TypeObject.Text),
            Tobject = Convert.ToString(NameObject.Text),
            InsuranceEvent = Convert.ToString(_ = new TextRange(TheCauseOfTheDamage.Document.ContentStart, TheCauseOfTheDamage.Document.ContentEnd).Text),
            RiskoFloss = Convert.ToString(_ = new TextRange(Contragent.Document.ContentStart, Contragent.Document.ContentEnd).Text),
            DamageCausedWithinTheLimitsOf = Convert.ToString(_ = new TextRange(CauseOfDamage.Document.ContentStart, CauseOfDamage.Document.ContentEnd).Text);
            PrintDoc print = new PrintDoc();
            var complate =
                (
                 Agent: "",
                 CompanyName: "",
                 LegalAddress: "",
                 MailingAddress: "",
                 PhoneFax: "",
                 INNAndKPP: "",
                 PaymentAccount: "",
                 Bank: "",
                 CorrespondentAccount: "",
                 BIC: "",
                 EMALL: "",
                 StartDate: "",
                 EndDate: "",
                 payment: "",
                 contribution: "",
                 FullName: "",
                 AdresClienta: "",
                 MailingAddressClienta: "",
                 PhoneClienta: "",
                 INNandKPPClienta: "",
                 PaymentAccountClient: "",
                 BankClient: "",
                 CorrespondentAccountClienta: "",
                 BICClient: "",
                 KPPClienta: "",
                 MSPasport: "",
                 objectType: "",
                 Tobject: "",
                 InsuranceEvent: "",
                 RiskoFloss: "",
                 DamageCausedWithinTheLimitsOf: ""
                 );
            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = complate.LegalAddress,
                MailingAddress = complate.MailingAddress,
                PhoneFax = complate.PhoneFax,
                INNAndKPP = complate.INNAndKPP,
                PaymentAccount = complate.PaymentAccount,
                Bank = complate.Bank,
                CorrespondentAccount = complate.CorrespondentAccount,
                BIC = complate.BIC,
                EMALL = complate.EMALL,
                CompanyName = complate.CompanyName
            };
            _ = new List<Insurer<string>> { insurer };
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                complate =
                (Agent,
                 CompanyName: x.Attribute("CompanyName").Value + " ",
                 LegalAddress: x.Element("LegalAddress").Value + " ",
                 MailingAddress: x.Element("MailingAddress").Value + " ",
                 PhoneFax: x.Element("PhoneFax").Value + " ",
                 INNAndKPP: x.Element("INNAndKPP").Value + " ",
                 PaymentAccount: x.Element("PaymentAccount").Value + " ",
                 Bank: x.Element("Bank").Value + " ",
                 CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                 BIC: x.Element("BIC").Value + " ",
                 EMALL: x.Element("EMALL").Value + " ",
                 StartDate,
                 EndDate,
                 payment,
                 contribution,
                 FullName,
                 AdresClienta,
                 MailingAddressClienta,
                 PhoneClienta,
                 INNandKPPClienta,
                 PaymentAccountClient,
                 BankClient,
                 CorrespondentAccountClienta,
                 BICClient,
                 KPPClienta,
                 MSPasport,
                 objectType,
                 Tobject,
                 InsuranceEvent,
                 RiskoFloss,
                 DamageCausedWithinTheLimitsOf
                );
                print.PrintDocument(
             complate.StartDate,
             complate.EndDate,
             complate.CompanyName,
             complate.Agent,
             complate.FullName,
             complate.contribution,
             complate.payment,
             complate.LegalAddress,
             complate.MailingAddress,
             complate.PhoneFax,
             complate.INNAndKPP,
             complate.PaymentAccount,
             complate.Bank,
             complate.CorrespondentAccount,
             complate.BIC,
             complate.AdresClienta,
             complate.MailingAddressClienta,
             complate.PhoneClienta,
             complate.BICClient,
             complate.PaymentAccountClient,
             complate.BankClient,
             complate.CorrespondentAccountClienta,
             complate.BICClient,
             complate.KPPClienta,
             complate.MSPasport,
             complate.objectType,
             complate.Tobject,
             complate.InsuranceEvent,
             complate.RiskoFloss,
             complate.DamageCausedWithinTheLimitsOf
             );
            }
        }
        private void PrintIntellectualProperty()
        {
            string
          Famile = Convert.ToString(ClientList.Text),
          contribution = Convert.ToString(TextViewInsuranceSum.Text),
          payment = Convert.ToString(TextInsuranceSumm.Text),
          StartDate = Convert.ToString(TextStartDate.Text),
          EndDate = Convert.ToString(TextEndDate.Text),
          Agent = Convert.ToString(TextAgent.Text),
          FullName = Famile + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", Famile)
          + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", Famile) + " ",
          AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", Famile) + " ",
          MailingAddressClienta = Bd.ReturnValues(connectionString, "SELECT MailingAddress FROM Clients where Surname like", Famile) + " ",
          PhoneClienta = Bd.ReturnValues(connectionString, "SELECT Phone FROM Clients where Surname like", Famile) + " ",
          INNandKPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          PaymentAccountClient = Bd.ReturnValues(connectionString, "SELECT PaymentAccount FROM Clients where Surname like", Famile) + " ",
          BankClient = Bd.ReturnValues(connectionString, "SELECT Bank FROM Clients where Surname like", Famile) + " ",
          CorrespondentAccountClienta = Bd.ReturnValues(connectionString, "SELECT CorrespondentAccount FROM Clients where Surname like", Famile) + " ",
          BICClient = Bd.ReturnValues(connectionString, "SELECT BIC FROM Clients where Surname like", Famile) + " ",
          KPPClienta = Bd.ReturnValues(connectionString, "SELECT INNandKPP FROM Clients where Surname like", Famile) + " ",
          MSPasport = Bd.ReturnValues(connectionString, "SELECT MsPassport FROM Clients where Surname like", Famile) + " ",
          Specia = _ = new TextRange(SpecialConditions.Document.ContentStart, SpecialConditions.Document.ContentEnd).Text;
            PrintDoc print = new PrintDoc();
            var complate =
                (
                 Agent: "",
                 CompanyName: "",
                 LegalAddress: "",
                 MailingAddress: "",
                 PhoneFax: "",
                 INNAndKPP: "",
                 PaymentAccount: "",
                 Bank: "",
                 CorrespondentAccount: "",
                 BIC: "",
                 EMALL: "",
                 StartDate: "",
                 EndDate: "",
                 payment: "",
                 contribution: "",
                 FullName: "",
                 AdresClienta: "",
                 MailingAddressClienta: "",
                 PhoneClienta: "",
                 INNandKPPClienta: "",
                 PaymentAccountClient: "",
                 BankClient: "",
                 CorrespondentAccountClienta: "",
                 BICClient: "",
                 KPPClienta: "",
                 MSPasport: "",
                 Specia: ""
                 );
            Insurer<string> insurer = new Insurer<string>
            {
                LegalAddress = complate.LegalAddress,
                MailingAddress = complate.MailingAddress,
                PhoneFax = complate.PhoneFax,
                INNAndKPP = complate.INNAndKPP,
                PaymentAccount = complate.PaymentAccount,
                Bank = complate.Bank,
                CorrespondentAccount = complate.CorrespondentAccount,
                BIC = complate.BIC,
                EMALL = complate.EMALL,
                CompanyName = complate.CompanyName
            };
            _ = new List<Insurer<string>> { insurer };
            XDocument xdocload = XDocument.Load("settingCompany.xml");
            XElement root = xdocload.Element("settingCompany");
            foreach (XElement x in root.Elements("Company").ToList())
            {
                complate =
                (Agent,
                 CompanyName: x.Attribute("CompanyName").Value + " ",
                 LegalAddress: x.Element("LegalAddress").Value + " ",
                 MailingAddress: x.Element("MailingAddress").Value + " ",
                 PhoneFax: x.Element("PhoneFax").Value + " ",
                 INNAndKPP: x.Element("INNAndKPP").Value + " ",
                 PaymentAccount: x.Element("PaymentAccount").Value + " ",
                 Bank: x.Element("Bank").Value + " ",
                 CorrespondentAccount: x.Element("CorrespondentAccount").Value + " ",
                 BIC: x.Element("BIC").Value + " ",
                 EMALL: x.Element("EMALL").Value + " ",
                 StartDate,
                 EndDate,
                 payment,
                 contribution,
                 FullName,
                 AdresClienta,
                 MailingAddressClienta,
                 PhoneClienta,
                 INNandKPPClienta,
                 PaymentAccountClient,
                 BankClient,
                 CorrespondentAccountClienta,
                 BICClient,
                 KPPClienta,
                 MSPasport,
                 Specia
                );
            }
            print.PrintDocument(
                complate.StartDate,
                complate.EndDate,
                complate.CompanyName,
                complate.Agent,
                complate.FullName,
                complate.contribution,
                complate.payment,
                complate.LegalAddress,
                complate.MailingAddress,
                complate.PhoneFax,
                complate.INNAndKPP,
                complate.PaymentAccount,
                complate.Bank,
                complate.CorrespondentAccount,
                complate.BIC,
                complate.AdresClienta,
                complate.MailingAddressClienta,
                complate.PhoneClienta,
                complate.BICClient,
                complate.PaymentAccountClient,
                complate.BankClient,
                complate.CorrespondentAccountClienta,
                complate.BICClient,
                complate.KPPClienta,
                complate.MSPasport,
                complate.Specia
                );
        }

        private void CaseInclude(string Include)
        {

            string caseSwitch = Include;
            string IdClient, IdInsurance, IdAgent;
            IdClient = Bd.ReturnValues(connectionString, returnvalueClient, ClientList.Text);
            IdInsurance = Bd.ReturnValues(connectionString, returnvalueInsurance, InsuranceList.Text);
            IdAgent = Bd.ReturnValues(connectionString, returnvalueAgent, TextAgent.Text);
            string QueryAddContarct = $"insert contract (DateConclusions,ExpiryDate,InsuranceSum,TypeOfInsurance,AgentId,ClientId,TheRatioOfInsurance)" +
                $" values (CONVERT(DATETIME,'{TextStartDate.Text}',103),CONVERT(DATETIME,'{TextEndDate.Text}',103),{TextInsuranceSumm.Text},{IdInsurance},{IdAgent},{IdClient},{TextInsurance.Text})";
            switch (caseSwitch)
            {
                case "Жизни":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                        String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                         && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                         && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                         && String.IsNullOrEmpty(TextEndDate.Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintLifeInsurance();
                        View.Show();
                        this.Close();
                    }
                    break;
                case "Животных при перевозке":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                       String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                        && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                        && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                        && String.IsNullOrEmpty(TextEndDate.Text) && String.IsNullOrEmpty(PlaceDeparture.Text)
                        && String.IsNullOrEmpty(Destination.Text) && String.IsNullOrEmpty(Nickname.Text)
                        && String.IsNullOrEmpty(Transport.Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintAnimalsByTransportation();
                        View.Show();
                        this.Close();
                    }
                    break;
                case "Другое":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                         String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                       && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                       && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                       && String.IsNullOrEmpty(TextEndDate.Text) && String.IsNullOrEmpty(_ = new TextRange(NameInsurance.Document.ContentStart, NameInsurance.Document.ContentEnd).Text)
                       && String.IsNullOrEmpty(_ = new TextRange(InsuranceEvent.Document.ContentStart, InsuranceEvent.Document.ContentEnd).Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintUniversalTreaty();
                        View.Show();
                        this.Close();
                    }
                    break;
                case "Жилью":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                                        String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                                         && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                                         && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                                         && String.IsNullOrEmpty(TextEndDate.Text) && String.IsNullOrEmpty(LoanAgreementNumber.Text)
                                         && String.IsNullOrEmpty(AdresHome.Text) && String.IsNullOrEmpty(LoanAgreement.Text)
                                         && String.IsNullOrEmpty(FloorHome.Text) && String.IsNullOrEmpty(PlaceFloorHome.Text)
                                         && String.IsNullOrEmpty(NumberFlat.Text) && String.IsNullOrEmpty(TotalArea.Text)
                                         && String.IsNullOrEmpty(Rooms.Text) && String.IsNullOrEmpty(_ = new TextRange(DocumentoOfTheRightToResidentialSpace.Document.ContentStart, DocumentoOfTheRightToResidentialSpace.Document.ContentEnd).Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintContractHomeInsurance();
                        View.Show();
                        this.Close();
                    }
                    break;
                case "Имущество":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                         String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                      && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                      && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                      && String.IsNullOrEmpty(TextEndDate.Text) && String.IsNullOrEmpty(TypeObject.Text)
                      && String.IsNullOrEmpty(NameObject.Text)
                      && String.IsNullOrEmpty(_ = new TextRange(TheCauseOfTheDamage.Document.ContentStart, TheCauseOfTheDamage.Document.ContentEnd).Text)
                      && String.IsNullOrEmpty(_ = new TextRange(Contragent.Document.ContentStart, Contragent.Document.ContentEnd).Text)
                      && String.IsNullOrEmpty(_ = new TextRange(CauseOfDamage.Document.ContentStart, CauseOfDamage.Document.ContentEnd).Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintAContractForPropertyInsurance();
                        View.Show();
                        this.Close();
                    }
                    break;
                case "Интеллектуальная собственность":
                    if (String.IsNullOrEmpty(ClientList.Text) && String.IsNullOrEmpty(TextAgent.Text) &&
                       String.IsNullOrEmpty(InsuranceList.Text) && String.IsNullOrEmpty(TextInsuranceSumm.Text)
                    && String.IsNullOrEmpty(TextInsurance.Text) && String.IsNullOrEmpty(TextViewInsuranceSum.Text)
                    && String.IsNullOrEmpty(TextViewInsurancePrize.Text) && String.IsNullOrEmpty(TextStartDate.Text)
                    && String.IsNullOrEmpty(TextEndDate.Text)
                    && String.IsNullOrEmpty(_ = new TextRange(SpecialConditions.Document.ContentStart, SpecialConditions.Document.ContentEnd).Text))
                    {
                        MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Bd.NewAdd(connectionString, QueryAddContarct);
                        PrintStatements();
                        PrintIntellectualProperty();
                        View.Show();
                        this.Close();
                    }
                    break;

            }

        }
        private void ButtonClickCancel(object sender, RoutedEventArgs e)
        {
            View.Show();
            this.Close();
        }
        private void TextChangedListClient(object sender, EventArgs e)
        {
            FullName = ClientList.Text + " " + Bd.ReturnValues(connectionString, "SELECT Name FROM Clients where Surname like", ClientList.Text)
            + " " + Bd.ReturnValues(connectionString, "SELECT Otchestvo FROM Clients where Surname like", ClientList.Text) + " ";
            AdresClienta = Bd.ReturnValues(connectionString, "SELECT Adres FROM Clients where Surname like", ClientList.Text) + " ";
        }
        private void NumericKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            bool isNumPadNumeric = (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);
            bool isNumeric = ((e.Key >= Key.D0 && e.Key <= Key.D9) && (e.KeyboardDevice.Modifiers == ModifierKeys.None));
            bool isDecimal = ((e.Key == Key.OemPeriod || e.Key == Key.Decimal) && (((System.Windows.Controls.TextBox)sender).Text.IndexOf('.') < 0));
            e.Handled = !(isNumPadNumeric || isNumeric || isDecimal);
            try
            {
                if (Convert.ToInt32(TextInsurance.Text) > 0 || Convert.ToInt32(TextInsuranceSumm.Text) > 0)
                {
                    TextViewInsuranceSum.Text = (Convert.ToDouble(TextInsuranceSumm.Text) * Convert.ToDouble(TextInsurance.Text)).ToString();
                    TextViewInsurancePrize.Text = (Convert.ToDouble(TextInsuranceSumm.Text) * (Convert.ToDouble(TextInsurance.Text) / 100)).ToString();
                }

            }
            catch
            {

            }
        }
        private void ComboBox_Selected(object sender, EventArgs e)
        {
            OnTextChanged(InsuranceList.Text);
        }
        private void OnTextChanged(string Switch)
        {
            switch (Switch)
            {
                case "Животных при перевозке":
                    Statement = "Животных при перевозке";
                    ImgInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.SelectedIndex = 1;
                    SelectInsurance.SelectedItem = Animals;
                    SelectInsurance.SelectedValue = Animals;
                    EndDate = StartDate.AddMonths(1);
                    TextEndDate.Text = EndDate.ToShortDateString();
                    break;
                case "Имущество":
                    ImgInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.Visibility = Visibility.Visible;
                    Statement = "Имущество";
                    SelectInsurance.SelectedIndex = 2;
                    SelectInsurance.SelectedItem = Item;
                    SelectInsurance.SelectedValue = Item;
                    break;
                case "Интеллектуальная собственность":
                    ImgInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.Visibility = Visibility.Visible;
                    Statement = "Интеллектуальной собственности";
                    SelectInsurance.SelectedIndex = 3;
                    SelectInsurance.SelectedItem = IntellectualProperty;
                    SelectInsurance.SelectedValue = IntellectualProperty;
                    break;
                case "Жилью":
                    ImgInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.Visibility = Visibility.Visible;
                    Statement = "Жилья";
                    SelectInsurance.SelectedIndex = 4;
                    SelectInsurance.SelectedItem = Home;
                    SelectInsurance.SelectedValue = Home;

                    break;
                case "Другое":
                    ImgInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.Visibility = Visibility.Visible;
                    SelectInsurance.SelectedIndex = 5;
                    SelectInsurance.SelectedItem = Other;
                    SelectInsurance.SelectedValue = Other;
                    EndDate = StartDate.AddMonths(1);
                    TextEndDate.Text = EndDate.ToShortDateString();
                    Statement = _ = new TextRange(NameInsurance.Document.ContentStart, NameInsurance.Document.ContentEnd).Text;
                    break;
                case "Жизни":
                    ImgInsurance.Visibility = Visibility.Hidden;
                    SelectInsurance.Visibility = Visibility.Hidden;
                    Statement = "Жизни";
                    break;
            }
        }

    }


}
