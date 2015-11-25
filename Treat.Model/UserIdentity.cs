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

        public string ExternalId
        {
            get { return Name; }
        }

        public User User { get; set; }

        public static UserIdentity Current
        {
            get { return Thread.CurrentPrincipal.Identity as UserIdentity; }
        }
    }
}
