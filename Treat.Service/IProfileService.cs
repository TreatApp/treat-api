using System.Collections.Generic;
using Treat.Model;

namespace Treat.Service
{
    public interface IProfileService
    {
        User GetUser();
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}