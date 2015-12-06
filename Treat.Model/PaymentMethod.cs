using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DataMember]
        public long UserId { get; set; }

        [Required]
        [DataMember]
        public PaymentMethodType Type { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string ExternalId { get; set; }
    }
}