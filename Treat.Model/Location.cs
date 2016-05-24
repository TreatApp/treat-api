using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class Location
    {
        [DataMember]
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
    }
}