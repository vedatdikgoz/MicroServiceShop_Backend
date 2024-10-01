namespace MicroServiceShop.Invoice.WebAPI.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string InvoiceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
