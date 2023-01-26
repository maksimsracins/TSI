using Online_Banking_System.data.models;

namespace Online_Banking_System.data.interfaces
{
    public interface IAdminServices
    {
        IEnumerable<Account> getAllAccounts(Client client);
    }
}
