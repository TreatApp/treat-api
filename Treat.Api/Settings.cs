using System.Configuration;
using Treat.Model;

namespace Treat.Api
{
    public class Settings : ISettings
    {
        public string StripeApiKey { get; set; }
        public string DbConnectionString { get; set; }
        public string StorageConnectionString { get; set; }

        public Settings()
        {
            StripeApiKey = ConfigurationManager.AppSettings["StripeApiKey"];
            DbConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            StorageConnectionString = ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString;
        }
    }
}