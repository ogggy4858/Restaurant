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
    public class FoodRepository : IFoodRepository
    {
        private readonly RestaurantDbContext _context;

        public FoodRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        private bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            var model = _context.Foods.Where(x => x.Name == name && x.Status != Common.CommonStatus.Delete).FirstOrDefault();
            if (model == null)
            {
                return true;
            }
            return false;
        }

        public void Create(FoodVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            if (CheckName(model.Name))
            {
                var a = new Food()
                {
                    Name = model.Name,
                    Description = model.Description,
                    FoodCategoryId = model.FoodCategoryId,
                    Id = Guid.NewGuid(),
                    Image = model.Image,
                    Price = model.Price,
                    Status = Common.CommonStatus.Active,
                    CreateDate = DateTime.Now,
                    OrderIndex = GetNextOrder()
                };

                _context.Foods.Add(a);
                _context.SaveChanges();
            }
        }

        private long GetNextOrder()
        {
            var max = _context.Foods.OrderByDescending(x => x.OrderIndex).FirstOrDefault();
            if(max == null)
            {
                return 1;
            }
            return max.OrderIndex + 1;
        }

        public void Delete(Guid id)
        {
            var detail = Detail(id);
            detail.Status = Common.CommonStatus.Delete;
            _context.SaveChanges();
        }

        public Food Detail(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            var detail = _context.Foods.Find(id);
            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail;

        }

        public FoodVM DetailViewModel(Guid id)
        {
            var detail = Detail(id);
            return new FoodVM()
            {
                Description = detail.Description,
                FoodCategoryId = detail.FoodCategoryId,
                Id = detail.Id,
                Image = detail.Image,
                Status = detail.Status,
                Price = detail.Price,
                Name = detail.Name,
                CreateDate = detail.CreateDate,
                OrderIndex = detail.OrderIndex
            };
        }

        public void Edit(FoodVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var detail = Detail(model.Id);
            detail.Image = model.Image;
            detail.Description = model.Description;
            detail.FoodCategoryId = model.FoodCategoryId;
            detail.Name = model.Name;
            detail.Price = model.Price;
            _context.SaveChanges();
        }

        public List<FoodVM> GetList()
        {
            return _context.Foods.Select(x => new FoodVM()
            {
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                Description = x.Description,
                FoodCategoryId = x.FoodCategoryId,
                FoodCategory = new FoodCategoryVM()
                {
                    Status = x.FoodCategory.Status,
                    Id = x.FoodCategory.Id,
                    Name = x.FoodCategory.Name
                },
                Status = x.Status,
                Price = x.Price,
                CreateDate = x.CreateDate,
                OrderIndex = x.OrderIndex
            })
            .OrderBy(x => x.OrderIndex)
            .ToList();
        }

        public IPagedList<FoodVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10)
        {
            var list = _context.Foods
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                searchKey = searchKey.Trim().ToLower();
                list = list.Where(x => x.Name.ToLower().Contains(searchKey));
            }

            if (status != null)
            {
                list = list.Where(x => x.Status == status);
            }
            else
            {
                list = list.Where(x => x.Status != Common.CommonStatus.Delete);
            }

            return list.Select(x => new FoodVM()
            {
                Name = x.Name,
                Id = x.Id,
                Image = x.Image,
                Description = x.Description,
                FoodCategoryId = x.FoodCategoryId,
                FoodCategory = new FoodCategoryVM()
                {
                    Status = x.FoodCategory.Status,
                    Id = x.FoodCategory.Id,
                    Name = x.FoodCategory.Name
                },
                Status = x.Status,
                Price = x.Price,
                CreateDate = x.CreateDate,
                OrderIndex = x.OrderIndex
            })
            .OrderBy(x => x.OrderIndex)
            .ToPagedList(page, pageSize);
        }
    }
}
