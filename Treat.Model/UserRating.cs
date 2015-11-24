using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("UserRating")]
    public class UserRating
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EventId { get; set; }
        
        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}