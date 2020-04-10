using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Interfaces
{
    public interface IDesignRepository
    {
        // banner
        Guid Create(DesignVM model, string categoryName, bool isDelete = false);
        List<DesignVM> GetList(string categoryName, bool? status = null);
        DesignVM DisplayBanner(string categoryName);
        void DeleteByCategory(string designCategoryName);
        List<DesignVM> DisplayInfo(string categoryName);
        DesignVM DisplayWelcome(string categoryName);
        void SetActive(Guid designId, string categoryName);
        List<DesignVM> DisplayService(string categoryName);
    }
}
