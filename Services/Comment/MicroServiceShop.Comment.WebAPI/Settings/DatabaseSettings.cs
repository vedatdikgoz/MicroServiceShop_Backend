namespace MicroServiceShop.Comment.WebAPI.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CommentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
