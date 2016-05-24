using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class BankAccount
    {
        [DataMember]
        public long Id { get; set; }

        [Required]
        [DataMember]
        public long UserId { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Number { get; set; }
    }
}