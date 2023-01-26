namespace Online_Banking_System.data.models
{
    public class Admin
    {
        private protected string? adminName { get; set; }
        private protected int adminId { get; set; }

        private protected List<Client>? clients { get; set; }
    }
}
