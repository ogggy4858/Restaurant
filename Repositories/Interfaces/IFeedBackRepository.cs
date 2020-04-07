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
    public interface IFeedBackRepository
    {
        Guid Create(FeedBackVM model);
        void Delete(Guid id);
        FeedBack Detail(Guid id);
        FeedBackVM DetailViewModel(Guid id);
        IPagedList<FeedBackVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10);
    }
}
