using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList;

namespace Repositories.Implementation
{
    public class DesignCategoryRepository : IDesignCategoryRepository
    {
        private readonly RestaurantDbContext _context;

        public DesignCategoryRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public void Create(DesignCategoryVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            DesignCategory cate = new DesignCategory()
            {
                Name = model.Name.Trim(),
                Status = Common.CommonStatus.Active
            };

            _context.DesignCategories.Add(cate);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var detail = Detail(id);
            detail.Status = Common.CommonStatus.Delete;
            _context.SaveChanges();
        }

        public DesignCategory Detail(long id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }

            var detail = _context.DesignCategories.Find(id);
            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail;
        }

        public DesignCategoryVM DetailViewModel(long id)
        {
            var detail = Detail(id);
            return new DesignCategoryVM()
            {
                Id = detail.Id,
                Name = detail.Name,
                Status = detail.Status
            };
        }

        public void Edit(DesignCategoryVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var detail = Detail(model.Id);
            detail.Name = model.Name.Trim();
            _context.SaveChanges();
        }

        public IPagedList<DesignCategoryVM> GetList(int page = 1, int pageSize = 10)
        {
            return _context.DesignCategories
                .Where(x => x.Status != Common.CommonStatus.Delete)
                .Select(x => new DesignCategoryVM()
                {
                    Status = x.Status,
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Status)
                .ToPagedList(page, pageSize);
        }
    }
}
