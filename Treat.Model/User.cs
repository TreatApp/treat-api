using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("User")]
    public class User
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string ExternalId { get; set; }

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
    }
}
