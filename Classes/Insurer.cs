namespace Kursach.Classes
{
    class Insurer<T>
    {
        private T companyname;
        public T CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }
        private T legaladdress;
        public T LegalAddress
        {
            get { return legaladdress; }
            set { legaladdress = value; }
        }
        private T mailingaddress;
        public T MailingAddress
        {
            get { return mailingaddress; }
            set { mailingaddress = value; }
        }
        private T phonefax;
        public T PhoneFax
        {
            get { return phonefax; }
            set { phonefax = value; }
        }
        private T INNandKPP;
        public T INNAndKPP
        {
            get { return INNandKPP; }
            set { INNandKPP = value; }
        }
        private T paymentaccount;
        public T PaymentAccount
        {
            get { return paymentaccount; }
            set { paymentaccount = value; }
        }
        private T bank;
        public T Bank
        {
            get { return bank; }
            set { bank = value; }
        }
        private T correspondentaccount;
        public T CorrespondentAccount
        {
            get { return correspondentaccount; }
            set { correspondentaccount = value; }
        }
        private T bic;
        public T BIC
        {
            get { return bic; }
            set { bic = value; }
        }
        private T emall;
        public T EMALL
        {
            get { return emall; }
            set { emall = value; }
        }

    }
}
