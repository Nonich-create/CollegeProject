using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Kursach.Classes
{
    class PrintDoc
    {
        readonly Print print = new Print();
        public void ReadyMadeApplications<T>(T statement, T date, T cansledate, T agent, T client, T summaVP, T adresClient)
        {
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(Application.StartupPath + "\\Statements.DOCX");
                print.ReplaceWordStub("{statement}", Convert.ToString(statement), WordDocument);
                print.ReplaceWordStub("{date}", Convert.ToString(date), WordDocument);
                print.ReplaceWordStub("{date1}", Convert.ToString(date), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{cansledate}", Convert.ToString(cansledate), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\ReadyMadeApplications.doc");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\ReadyMadeApplications.doc");
            }
            finally
            {
                WordApp.Quit();
            }
        }
        public void PrintDocument<T>(T StartDate, T EndDate, T namecompany, T agent, T client, T summaOPL, T summaVP,
      T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
      T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
      T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta, T MSPasport)
        {
            string TempLateFileName = (Application.StartupPath + "\\ContractLifeInsurance.doc");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{StartDate}", Convert.ToString(StartDate), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{client1}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{client2}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{EndDate}", Convert.ToString(EndDate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewContractLifeInsurance.doc");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewContractLifeInsurance.doc");
            }
            finally
            {
                WordApp.Quit();
            }
        }
        public void PrintDocument<T>(T date, T cansledate, T namecompany, T agent, T client, T summaOPL, T summaVP,
         T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
         T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
         T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta,
         T PlaceOfDeparture, T TheirDestination, T AnimalsName, T ModeOfTransport, T MSPasport)
        {
            string TempLateFileName = (Application.StartupPath + "\\IncludeAnimalsByTransportation.DOCX");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{PlaceOfDeparture}", Convert.ToString(PlaceOfDeparture), WordDocument);
                print.ReplaceWordStub("{TheirDestination}", Convert.ToString(TheirDestination), WordDocument);
                print.ReplaceWordStub("{AnimalsName}", Convert.ToString(AnimalsName), WordDocument);
                print.ReplaceWordStub("{ModeOfTransport}", Convert.ToString(ModeOfTransport), WordDocument);
                print.ReplaceWordStub("{ModeOfTransport1}", Convert.ToString(ModeOfTransport), WordDocument);
                print.ReplaceWordStub("{StartDate}", Convert.ToString(date), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{client1}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{EndDate}", Convert.ToString(cansledate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewIncludeAnimalsByTransportation.DOCX");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewIncludeAnimalsByTransportation.DOCX");
            }
            finally
            {
                WordApp.Quit();
            }
        }
        public void PrintDocument<T>(T date, T cansledate, T namecompany, T agent, T client, T summaOPL, T summaVP,
      T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
      T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
      T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta, T UniversalTreaty,
      T InsuranceEvent, T MSPasport)
        {
            string TempLateFileName = (Application.StartupPath + "\\UniversalTreaty.doc");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{date}", Convert.ToString(date), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{client1}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{client2}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{cansledate}", Convert.ToString(cansledate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{UniversalTreaty}", Convert.ToString(UniversalTreaty), WordDocument);
                print.ReplaceWordStub("{InsuranceEvent}", Convert.ToString(InsuranceEvent), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewUniversalTreaty.doc");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewUniversalTreaty.doc");
            }
            finally
            {
                WordApp.Quit();
            }
        }
        public void PrintDocument<T>(T StartDate, T EndDate, T namecompany, T agent, T client, T summaOPL, T summaVP,
         T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
         T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
         T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta, T Loanagreement,
         T Loanagreementnumber, T adres, T room, T S, T storey, T level, T number, T DocumentOfTheRightToResidentialSpace,
         T MSPasport)
        {
            string TempLateFileName = (Application.StartupPath + "\\ContractHomeInsurance.DOCX");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{StartDate}", Convert.ToString(StartDate), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{client1}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{client2}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{EndDate}", Convert.ToString(EndDate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{Loanagreement}", Convert.ToString(Loanagreement), WordDocument);
                print.ReplaceWordStub("{Loanagreementnumber}", Convert.ToString(Loanagreementnumber), WordDocument);
                print.ReplaceWordStub("{adres}", Convert.ToString(adres), WordDocument);
                print.ReplaceWordStub("{room}", Convert.ToString(room), WordDocument);
                print.ReplaceWordStub("{S}", Convert.ToString(S), WordDocument);
                print.ReplaceWordStub("{storey}", Convert.ToString(storey), WordDocument);
                print.ReplaceWordStub("{level}", Convert.ToString(level), WordDocument);
                print.ReplaceWordStub("{number}", Convert.ToString(number), WordDocument);
                print.ReplaceWordStub("{DocumentOfTheRightToResidentialSpace}", Convert.ToString(DocumentOfTheRightToResidentialSpace), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewContractHomeInsurance.DOCX");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewContractHomeInsurance.DOCX");
            }
            finally
            {
                WordApp.Quit();
            }
        }
        public void PrintDocument<T>(T StartDate, T EndDate, T namecompany, T agent, T client, T summaOPL, T summaVP,
           T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
           T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
           T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta, T MSPasport,
           T objectType, T Tobject, T InsuranceEvent, T RiskoFloss, T DamageCausedWithinTheLimitsOf)
        {
            string TempLateFileName = (Application.StartupPath + "\\AContractForPropertyInsurance.doc");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{StartDate}", Convert.ToString(StartDate), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{EndDate}", Convert.ToString(EndDate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                print.ReplaceWordStub("{objectType}", Convert.ToString(objectType), WordDocument);
                print.ReplaceWordStub("{object}", Convert.ToString(Tobject), WordDocument);
                print.ReplaceWordStub("{InsuranceEvent}", Convert.ToString(InsuranceEvent), WordDocument);
                print.ReplaceWordStub("{RiskoFloss}", Convert.ToString(RiskoFloss), WordDocument);
                print.ReplaceWordStub("{DamageCausedWithinTheLimitsOf}", Convert.ToString(DamageCausedWithinTheLimitsOf), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewAContractForPropertyInsurance.doc");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewAContractForPropertyInsurance.doc");
            }
            finally
            {
                WordApp.Quit();
            }

        }
        public void PrintDocument<T>(T StartDate, T EndDate, T namecompany, T agent, T client, T summaOPL, T summaVP,
        T yarAdres, T mailpostal, T phonecompany, T IHHcompany, T PaymentCompany, T bank,
        T Corpayment, T BIC, T adresClient, T mailpostalclient, T phoneclient,
        T BICClient, T paymentclient, T ClientBank, T corpaymentclient, T BICCLient, T KPPClienta, T MSPasport,
        T Specia)
        {
            string TempLateFileName = (Application.StartupPath + "\\IntellectualProperty.doc");
            var WordApp = new Word.Application
            {
                Visible = false
            };
            try
            {
                var WordDocument = WordApp.Documents.Open(TempLateFileName);
                print.ReplaceWordStub("{StartDate}", Convert.ToString(StartDate), WordDocument);
                print.ReplaceWordStub("{yarAdres}", Convert.ToString(yarAdres), WordDocument);
                print.ReplaceWordStub("{namecompany}", Convert.ToString(namecompany), WordDocument);
                print.ReplaceWordStub("{agent}", Convert.ToString(agent), WordDocument);
                print.ReplaceWordStub("{client}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaOPL}", Convert.ToString(summaOPL), WordDocument);
                print.ReplaceWordStub("{client1}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{client2}", Convert.ToString(client), WordDocument);
                print.ReplaceWordStub("{summaVP}", Convert.ToString(summaVP), WordDocument);
                print.ReplaceWordStub("{EndDate}", Convert.ToString(EndDate), WordDocument);
                print.ReplaceWordStub("{mailpostal}", Convert.ToString(mailpostal), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{IHHcompany}", Convert.ToString(IHHcompany), WordDocument);
                print.ReplaceWordStub("{PaymentCompany}", Convert.ToString(PaymentCompany), WordDocument);
                print.ReplaceWordStub("{bank}", Convert.ToString(bank), WordDocument);
                print.ReplaceWordStub("{Corpayment}", Convert.ToString(Corpayment), WordDocument);
                print.ReplaceWordStub("{BIC}", Convert.ToString(BIC), WordDocument);
                print.ReplaceWordStub("{adresClient}", Convert.ToString(adresClient), WordDocument);
                print.ReplaceWordStub("{mailpostalclient}", Convert.ToString(mailpostalclient), WordDocument);
                print.ReplaceWordStub("{phoneclient}", Convert.ToString(phoneclient), WordDocument);
                print.ReplaceWordStub("{KPPClienta}", Convert.ToString(KPPClienta), WordDocument);
                print.ReplaceWordStub("{paymentclient}", Convert.ToString(paymentclient), WordDocument);
                print.ReplaceWordStub("{ClientBank}", Convert.ToString(ClientBank), WordDocument);
                print.ReplaceWordStub("{corpaymentclient}", Convert.ToString(corpaymentclient), WordDocument);
                print.ReplaceWordStub("{BICCLient}", Convert.ToString(BICCLient), WordDocument);
                print.ReplaceWordStub("{phonecompany}", Convert.ToString(phonecompany), WordDocument);
                print.ReplaceWordStub("{MSPasport}", Convert.ToString(MSPasport), WordDocument);
                print.ReplaceWordStub("{Specia}", Convert.ToString(Specia), WordDocument);
                WordDocument.SaveAs(Application.StartupPath + "\\NewIntellectualProperty.doc");
                WordDocument.Close();
                print.IPrintDocument(Application.StartupPath + "\\NewIntellectualProperty.doc");
            }
            finally
            {
                WordApp.Quit();
            }
        }
    }
}
