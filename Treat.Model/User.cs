using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string ExternalId { get; set; }

        [DataMember]
        [StringLength(50)]
        public string PaymentId { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string LastName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public decimal Rating { get; set; }
    }
}
