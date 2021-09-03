namespace sample_ms.Models
{

    public class AccountantDatabaseSettings : IAccountantDatabaseSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string AccountCollectionName { get; set; }
    }

    public interface IAccountantDatabaseSettings
    {
        string Database { get; set; }
        string ConnectionString { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string AccountCollectionName { get; set; }
    }

}