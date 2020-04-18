using Common;
using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList.Mvc;
using X.PagedList;
using Repositories.StaticData;

namespace Repositories.Implementation
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly RestaurantDbContext _context;

        public FoodCategoryRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        private bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            var check = _context.FoodCategories
                .Where(x => x.Name == name.Trim() && x.Status != Common.CommonStatus.Delete)
                .FirstOrDefault();
            if (check == null)
            {
                return true;
            }
            return false;
        }

        public void Create(FoodCategoryVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }
            if (CheckName(model.Name))
            {
                FoodCategory food = new FoodCategory()
                {
                    Name = model.Name.Trim(),
                    Status = CommonStatus.Active
                };

                _context.FoodCategories.Add(food);
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var detail = Detail(id);
            detail.Status = CommonStatus.Delete;
            _context.SaveChanges();
        }

        public FoodCategory Detail(long id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }

            var detail = _context.FoodCategories.Find(id);

            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail;
        }

        public FoodCategoryVM DetailViewModel(long id)
        {
            var detail = Detail(id);
            return new FoodCategoryVM()
            {
                Id = detail.Id,
                Foods = detail.Foods.Select(x => new FoodVM()
                {
                    Description = x.Description,
                    Status = x.Status,
                    Id = x.Id,
                    FoodCategoryId = x.FoodCategoryId,
                }).ToList(),
                Name = detail.Name,
                Status = detail.Status
            };
        }

        public List<FoodCategoryVM> DropdownList()
        {
            var list = _context.FoodCategories
                .Where(x => x.Status != CommonStatus.Delete)
               .AsQueryable();

            return list.Select(x => new FoodCategoryVM()
            {
                Foods = x.Foods.Select(a => new FoodVM()
                {
                    Description = a.Description,
                    FoodCategoryId = a.FoodCategoryId,
                    Id = a.Id,
                    Image = a.Image,
                    Price = a.Price,
                    Status = a.Status
                }).ToList(),
                Id = x.Id,
                Status = x.Status,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .ToList();
        }

        public IPagedList<FoodCategoryVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10)
        {
            var list = _context.FoodCategories
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                searchKey = searchKey.Trim().ToLower();
                list = list.Where(x => x.Name.Contains(searchKey));
            }

            if (status != null)
            {
                list = list.Where(x => x.Status == status);
            }
            else
            {
                list = list.Where(x => x.Status == true);
            }

            return list.Select(x => new FoodCategoryVM()
            {
                Foods = x.Foods.Select(a => new FoodVM()
                {
                    Description = a.Description,
                    FoodCategoryId = a.FoodCategoryId,
                    Id = a.Id,
                    Image = a.Image,
                    Price = a.Price,
                    Status = a.Status
                }).ToList(),
                Id = x.Id,
                Status = x.Status,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .ToPagedList(page, pageSize);
        }

        public List<FoodCategoryVM> DisplayFoodCategories()
        {
            var list = _context.FoodCategories
                .Where(x => x.Status != Common.CommonStatus.Delete)
                .OrderBy(x => x.Name)
                .Select(x => new FoodCategoryVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Foods = x.Foods
                    .Where(a => a.Status != CommonStatus.Delete)
                    .OrderBy(a => Guid.NewGuid()).Take(3)
                    .Select(a => new FoodVM()
                    {
                        Status = a.Status,
                        Description = a.Description,
                        Image = a.Image,
                        FoodCategoryId = a.FoodCategoryId,
                        Id = a.Id,
                        Price = a.Price,
                        Name = a.Name
                    }).ToList()
                }).ToList();

            if (list == null)
            {
                return CommonData.DisplayFoodCategory;
            }

            if (list.Count == 0)
            {
                return CommonData.DisplayFoodCategory;
            }

            return list;
        }

        public List<FoodCategoryVM> GetList()
        {
            var list = _context.FoodCategories.Where(x => x.Status == Common.CommonStatus.Active)
                .Select(x => new FoodCategoryVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status
                }).ToList();
            if(list == null)
            {
                return CommonData.DisplayFoodCategoryMenu;
            }

            return list;
        }
    }
}
