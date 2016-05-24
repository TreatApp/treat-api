using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class EventImage
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long EventId { get; set; }

        [Required]
        [DataMember]
        public string FileName { get; set; }
    }
}