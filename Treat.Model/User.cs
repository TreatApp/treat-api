using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("User")]
    public class User
    {
        public User()
        {
            UserRatings = new HashSet<UserRating>();
            PaymentMethods = new HashSet<PaymentMethod>();
            BankAccounts = new HashSet<BankAccount>();
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [DataMember]
        [StringLength(50)]
        public string ExternalId { get; set; }

        [DataMember]
        [StringLength(50)]
        public string PaymentId { get; set; }

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

        [DataMember]
        public double Rating { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }

        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
