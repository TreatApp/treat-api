using Treat.Model;

namespace Treat.Repository
{
    public class Database : PetaPoco.Database
    {
        public Database(ISettings settings) : base(settings.DbConnectionString)
        {
        }
    }
}
