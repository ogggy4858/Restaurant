using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public List<string> List()
        {
            return new List<string>()
            {
                "1", "2", "3"
            };
        }
    }
}
