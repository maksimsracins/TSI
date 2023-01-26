using Online_Banking_System.data.interfaces;
using Online_Banking_System.data.models;

namespace Online_Banking_System.data.services
{
    public class ClientServices : IClientServices
    {
        public long getAccountBalance(Account account) =>
            account.AccountBalance;

        public int getAccountCount(Client client) =>
            client.Accounts.Count;


        public IEnumerable<Account> getAllAccounts(Client client)
        {
            List<Account> accounts = new List<Account>();

            foreach (Account account in client.Accounts)
            {
                accounts.Add(account);
            }
            return accounts;
        }


    }
}
