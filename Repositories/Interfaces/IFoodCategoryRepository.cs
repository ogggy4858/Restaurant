using Models;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IFoodCategoryRepository
    {
        FoodCategory Detail(long id);
        FoodCategoryVM DetailViewModel(long id);
        IPagedList<FoodCategoryVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10);
        void Create(FoodCategoryVM model);
        void Delete(long id);
        List<FoodCategoryVM> DropdownList();
        List<FoodCategoryVM> DisplayFoodCategories();
        List<FoodCategoryVM> GetList();
    }
}
