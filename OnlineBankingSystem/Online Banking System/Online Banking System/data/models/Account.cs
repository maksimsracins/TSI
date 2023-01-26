namespace Online_Banking_System.data.models
{
    public class Account
    {
        private int accountId;
        private int accountNum;
        private long accountBalance;

        public int AccountId { 
            get { return accountId; } 
            set { accountId = value; }
        }
        public int AccountNum
        {
            get { return accountNum; }
            set { accountNum = value; }
        }
        public long AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }
    }
}
