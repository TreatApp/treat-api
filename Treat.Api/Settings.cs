using System.Configuration;
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
            BraintreeEnvironment = ConfigurationManager.AppSettings["BraintreeEnvironment"];
            BraintreeMerchantId = ConfigurationManager.AppSettings["BraintreeMerchantId"];
            BraintreePublicKey = ConfigurationManager.AppSettings["BraintreePublicKey"];
            BraintreePrivateKey = ConfigurationManager.AppSettings["BraintreePrivateKey"];
            DbConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            StorageConnectionString = ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
        }
    }
}