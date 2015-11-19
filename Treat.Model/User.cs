using System;

namespace Treat.Model
{
    public class User
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
