using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList;

namespace Repositories.Interfaces
{
    public interface IDesignRepository
    {
        // banner
        Guid Create(DesignVM model, string categoryName, bool isDelete = true);
        IPagedList<DesignVM> GetList(string categoryName, int page = 1, int pageSize = 10, bool? status = null);
        List<DesignVM> GetList(string categoryName, bool? status = null);
        DesignVM DisplayBanner(string categoryName);
        void DeleteByCategory(string designCategoryName);
        List<DesignVM> DisplayInfo(string categoryName);
        DesignVM DisplayWelcome(string categoryName);
        void SetActive(Guid designId, string categoryName);
        List<DesignVM> DisplayService(string categoryName);
        DesignVM DisplayHotMenu(string categoryName);
        DesignVM DisplayMenu(string categoryName);
        List<string> DisplayImage(string categoryName);
        List<DesignVM> DisplaySynthesizeInfo(string categoryName);
        string DisplayImageFoodCategory(string categoryName);
    }
}
