namespace Online_Banking_System.data.dto
{
    public class ClientDto
    {
        private int clientId { get; set; }
        private string clientName { get; set; }
        private List<Account> accounts { get; set; }
        private string clientStatus { get; set; }

        public int Id
        {
            get { return clientId; }
            set { clientId = value; }
        }
        public string Name
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public string Status
        {
            get { return clientStatus; }
            set
            {
                clientStatus = value;
            }
        }
        public List<Account> Accounts
        {
            get { return accounts; }
            set
            {
                accounts = value;
            }
        }
    }
}
