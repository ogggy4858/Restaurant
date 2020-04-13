using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IHotMenuRepository
    {
        HotMenuVM DetailViewModel(Guid id);
        HotMenu Detail(Guid id);
        List<HotMenuVM> List();
        void Create(HotMenuVM model);
        void Edit(HotMenuVM model);
        void DeleteAll();
        void SetActive(Guid id);
        HotMenuVM DisplayHotMenu();
    }
}
