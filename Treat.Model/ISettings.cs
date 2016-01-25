namespace Treat.Model
{
    public interface ISettings
    {
        string BraintreeEnvironment { get; set; }
        string BraintreeMerchantId { get; set; }
        string BraintreePublicKey { get; set; }
        string BraintreePrivateKey { get; set; }
        string DbConnectionString { get; set; }
        string StorageConnectionString { get; set; }
    }
}
