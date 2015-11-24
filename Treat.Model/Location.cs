using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("Location")]
    public class Location
    {
        public Location()
        {
            Events = new HashSet<Event>();
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Country { get; set; }
        
        [Required]
        [DataMember]
        public decimal Latitude { get; set; }

        [Required]
        [DataMember]
        public decimal Longitude { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}