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
    public interface IFoodRepository
    {
        Food Detail(Guid id);
        void Create(FoodVM model);
        void Edit(FoodVM model);
        void Delete(Guid id);
        FoodVM DetailViewModel(Guid id);
        IPagedList<FoodVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10);
    }
}
