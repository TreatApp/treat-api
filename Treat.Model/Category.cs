using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
