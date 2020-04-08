using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<UserVM> GetList();
        void SetRole(string userId, string roleName);
        void RemoveRole(string userId);
    }
}
