using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        IPagedList<UserVM> GetList(int page = 1, int pageSize = 10);
        void SetRole(string userId, string roleName);
        void RemoveRole(string userId);
        bool IsAdmin(string email);
    }
}
