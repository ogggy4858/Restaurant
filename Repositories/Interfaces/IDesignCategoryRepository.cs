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
    public interface IDesignCategoryRepository
    {
        void Create(DesignCategoryVM model);
        void Edit(DesignCategoryVM model);
        void Delete(long id);
        IPagedList<DesignCategoryVM> GetList(int page = 1, int pageSize = 10);
        DesignCategoryVM DetailViewModel(long id);
        DesignCategory Detail(long id);
    }
}
