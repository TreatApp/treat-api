using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class PaymentMethod
    {
        [DataMember]
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

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Description { get; set; }
    }
}