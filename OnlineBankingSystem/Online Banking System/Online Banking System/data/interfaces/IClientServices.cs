using Online_Banking_System.data.models;

namespace Online_Banking_System.data.interfaces
{
    public interface IClientServices
    {
        IEnumerable<Account> getAllAccounts(Client client);
        int getAccountCount(Client client);
        long getAccountBalance(Account account);
    }
}
