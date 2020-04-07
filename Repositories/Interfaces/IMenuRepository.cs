using Models;
using System;
using System.Collections.Generic;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IMenuRepository
    {
        MenuVM DetailViewModel(Guid id);
        Menu Detail(Guid id);
        List<MenuVM> List();
        void Create(MenuVM model);
        void Edit(MenuVM model);
        void DeleteAll();
        void SetActive(Guid id);
    }
}
