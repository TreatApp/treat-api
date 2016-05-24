using System.Security.Principal;
using System.Threading;

namespace Treat.Model
{
    public class UserIdentity : GenericIdentity
    {
        public UserIdentity(string externalId)
            : base(externalId, "Basic")
        {   
        }

        public string ExternalId => Name;

        public User User { get; set; }

        public static UserIdentity Current => Thread.CurrentPrincipal.Identity as UserIdentity;

        public static UserIdentity Anonymous => new UserIdentity(string.Empty)
        {
            User = new User
            {
                Id = 1
            }
        };
    }
}
