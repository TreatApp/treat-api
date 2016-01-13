﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("EventImage")]
    public class EventImage
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long EventId { get; set; }

        [Required]
        [DataMember]
        public string FileName { get; set; }

        public virtual Event Event { get; set; }
    }
}