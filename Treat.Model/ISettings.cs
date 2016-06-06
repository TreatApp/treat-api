namespace Treat.Model
{
    public interface ISettings
    {
        string StripeApiKey { get; set; }
        string DbConnectionString { get; set; }
        string StorageConnectionString { get; set; }
    }
}
