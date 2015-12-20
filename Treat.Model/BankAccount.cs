using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("BankAccount")]
    public class BankAccount
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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