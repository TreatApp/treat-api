using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Events = new HashSet<Event>();
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
