using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class UserSession
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string ExternalId { get; set; }

        [DataMember]
        public string PaymentToken { get; set; }
    }
}