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
        Guid Create(DesignVM model, string categoryName);
        List<DesignVM> GetList(string categoryName);
        DesignVM DisplayBanner(string categoryName);
    }
}
