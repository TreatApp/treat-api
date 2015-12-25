using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("EventTransaction")]
    public class EventTransaction
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EventId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}