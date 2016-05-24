using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class EventTransaction
    {
        [Required]
        [DataMember]
        public long EventId { get; set; }

        [Required]
        [DataMember]
        public long UserId { get; set; }

        [Required]
        [DataMember]
        public string ExternalId { get; set; }

        [Required]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [DataMember]
        public EventTransactionStatus Status { get; set; }
    }
}