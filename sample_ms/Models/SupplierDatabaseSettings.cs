namespace sample_ms.Models
{

    public class SupplierDatabaseSettings : ISupplierDatabaseSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string SupplierCollectionName { get; set; }
    }

    public interface ISupplierDatabaseSettings
    {
        string Database { get; set; }
        string ConnectionString { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string SupplierCollectionName { get; set; }
    }

}