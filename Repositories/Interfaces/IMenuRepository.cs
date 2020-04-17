using Models;
using System;
using System.Collections.Generic;
using ViewModels;
using X.PagedList;

namespace Repositories.Interfaces
{
    public interface IMenuRepository
    {
        MenuVM DetailViewModel(Guid id);
        Menu Detail(Guid id);
        IPagedList<MenuVM> GetList(int page = 1, int pageSize = 10);
        void Create(MenuVM model);
        void Edit(MenuVM model);
        void DeleteAll();
        void SetActive(Guid id);
        MenuVM DisplayMenu();
    }
}
