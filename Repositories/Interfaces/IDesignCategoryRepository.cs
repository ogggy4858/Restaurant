using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IDesignCategoryRepository
    {
        void Create(DesignCategoryVM model);
        void Edit(DesignCategoryVM model);
        void Delete(long id);
        List<DesignCategoryVM> GetList();
        DesignCategoryVM DetailViewModel(long id);
        DesignCategory Detail(long id);

    }
}
