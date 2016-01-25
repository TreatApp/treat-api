using Microsoft.WindowsAzure;
using Treat.Model;

namespace Treat.Api
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
            BraintreeEnvironment = CloudConfigurationManager.GetSetting("BraintreeEnvironment");
            BraintreeMerchantId = CloudConfigurationManager.GetSetting("BraintreeMerchantId");
            BraintreePublicKey = CloudConfigurationManager.GetSetting("BraintreePublicKey");
            BraintreePrivateKey = CloudConfigurationManager.GetSetting("BraintreePrivateKey");
            DbConnectionString = CloudConfigurationManager.GetSetting("DbConnectionString");
            StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
        }
    }
}