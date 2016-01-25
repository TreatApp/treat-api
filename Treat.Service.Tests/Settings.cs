using System.Configuration;
using Treat.Model;

namespace Treat.Service.Tests
{
    public class Settings : ISettings
    {
        public string BraintreeEnvironment { get; set; }
        public string BraintreeMerchantId { get; set; }
        public string BraintreePublicKey { get; set; }
        public string BraintreePrivateKey { get; set; }
        public string DbConnectionString { get; set; }
        public string StorageConnectionString { get; set; }

        public Settings()
        {
            BraintreeEnvironment = ConfigurationManager.AppSettings.Get("BraintreeEnvironment");
            BraintreeMerchantId = ConfigurationManager.AppSettings.Get("BraintreeMerchantId");
            BraintreePublicKey = ConfigurationManager.AppSettings.Get("BraintreePublicKey");
            BraintreePrivateKey = ConfigurationManager.AppSettings.Get("BraintreePrivateKey");
            DbConnectionString = ConfigurationManager.AppSettings.Get("DbConnectionString");
            StorageConnectionString = ConfigurationManager.AppSettings.Get("StorageConnectionString");
        }
    }
}