using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList;

namespace Repositories.Interfaces
{
    public interface IHotMenuRepository
    {
        HotMenuVM DetailViewModel(Guid id);
        HotMenu Detail(Guid id);
        IPagedList<HotMenuVM> GetList(int page = 1, int pageSize = 10);
        void Create(HotMenuVM model);
        void Edit(HotMenuVM model);
        void DeleteAll();
        void SetActive(Guid id);
        HotMenuVM DisplayHotMenu();
    }
}
