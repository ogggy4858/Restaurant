﻿using Models;
using Repositories.Interfaces;
using Repositories.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using X.PagedList;

namespace Repositories.Implementation
{
    public class HotMenuRepository : IHotMenuRepository
    {
        private RestaurantDbContext _context;

        public HotMenuRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public void Create(HotMenuVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            DeleteAll();
            HotMenu m = new HotMenu()
            {
                FoodId1 = model.FoodId1,
                FoodId2 = model.FoodId2,
                FoodId3 = model.FoodId3,
                FoodId4 = model.FoodId4,
                FoodId5 = model.FoodId5,
                FoodId6 = model.FoodId6,
                Id = Guid.NewGuid(),
                Status = Common.CommonStatus.Active,
                CreateDate = DateTime.Now
            };

            _context.HotMenus.Add(m);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var list = _context.HotMenus.Where(x => x.Status == Common.CommonStatus.Active);
            foreach (var item in list.ToList())
            {
                item.Status = Common.CommonStatus.Delete;
            }
        }

        public HotMenu Detail(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            var detail = _context.HotMenus.Find(id);

            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail;
        }

        public HotMenuVM DetailViewModel(Guid id)
        {
            var detail = Detail(id);

            return new HotMenuVM()
            {
                Id = detail.Id,
                FoodId1 = detail.FoodId1,
                FoodId2 = detail.FoodId2,
                FoodId3 = detail.FoodId3,
                FoodId4 = detail.FoodId4,
                FoodId5 = detail.FoodId5,
                FoodId6 = detail.FoodId6,
                Status = detail.Status,
                CreateDate = detail.CreateDate,
                Food = new FoodVM()
                {
                    Description = detail.Food.Description,
                    Status = detail.Food.Status,
                    Price = detail.Food.Price,
                    Name = detail.Food.Name,
                    FoodCategoryId = detail.Food.FoodCategoryId,
                    Id = detail.Food.Id,
                    Image = detail.Food.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food.FoodCategory.Id,
                        Name = detail.Food.FoodCategory.Name,
                        Status = detail.Food.FoodCategory.Status
                    }
                },
                Food1 = new FoodVM()
                {
                    Description = detail.Food1.Description,
                    Status = detail.Food1.Status,
                    Price = detail.Food1.Price,
                    Name = detail.Food1.Name,
                    FoodCategoryId = detail.Food1.FoodCategoryId,
                    Id = detail.Food1.Id,
                    Image = detail.Food1.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food1.FoodCategory.Id,
                        Name = detail.Food1.FoodCategory.Name,
                        Status = detail.Food1.FoodCategory.Status
                    }
                },
                Food2 = new FoodVM()
                {
                    Description = detail.Food2.Description,
                    Status = detail.Food2.Status,
                    Price = detail.Food2.Price,
                    Name = detail.Food2.Name,
                    FoodCategoryId = detail.Food2.FoodCategoryId,
                    Id = detail.Food2.Id,
                    Image = detail.Food2.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food2.FoodCategory.Id,
                        Name = detail.Food2.FoodCategory.Name,
                        Status = detail.Food2.FoodCategory.Status
                    }
                },
                Food3 = new FoodVM()
                {
                    Description = detail.Food3.Description,
                    Status = detail.Food3.Status,
                    Price = detail.Food3.Price,
                    Name = detail.Food3.Name,
                    FoodCategoryId = detail.Food3.FoodCategoryId,
                    Id = detail.Food3.Id,
                    Image = detail.Food3.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food3.FoodCategory.Id,
                        Name = detail.Food3.FoodCategory.Name,
                        Status = detail.Food3.FoodCategory.Status
                    }
                },
                Food4 = new FoodVM()
                {
                    Description = detail.Food4.Description,
                    Status = detail.Food4.Status,
                    Price = detail.Food4.Price,
                    Name = detail.Food4.Name,
                    FoodCategoryId = detail.Food4.FoodCategoryId,
                    Id = detail.Food4.Id,
                    Image = detail.Food4.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food4.FoodCategory.Id,
                        Name = detail.Food4.FoodCategory.Name,
                        Status = detail.Food4.FoodCategory.Status
                    }
                },
                Food5 = new FoodVM()
                {
                    Description = detail.Food5.Description,
                    Status = detail.Food5.Status,
                    Price = detail.Food5.Price,
                    Name = detail.Food5.Name,
                    FoodCategoryId = detail.Food5.FoodCategoryId,
                    Id = detail.Food5.Id,
                    Image = detail.Food5.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = detail.Food5.FoodCategory.Id,
                        Name = detail.Food5.FoodCategory.Name,
                        Status = detail.Food5.FoodCategory.Status
                    }
                }
            };
        }

        public void Edit(HotMenuVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var detail = Detail(model.Id);
            detail.FoodId1 = model.FoodId1;
            detail.FoodId2 = model.FoodId2;
            detail.FoodId3 = model.FoodId3;
            detail.FoodId4 = model.FoodId4;
            detail.FoodId5 = model.FoodId5;
            detail.FoodId6 = model.FoodId6;

            _context.SaveChanges();
        }

        public IPagedList<HotMenuVM> GetList(int page = 1, int pageSize = 10)
        {
            return _context.HotMenus.Select(x => new HotMenuVM()
            {
                CreateDate = x.CreateDate,
                Id = x.Id,
                FoodId1 = x.FoodId1,
                FoodId2 = x.FoodId2,
                FoodId3 = x.FoodId3,
                FoodId4 = x.FoodId4,
                FoodId5 = x.FoodId5,
                FoodId6 = x.FoodId6,
                Status = x.Status,
                Food = new FoodVM()
                {
                    Description = x.Food.Description,
                    Status = x.Food.Status,
                    Price = x.Food.Price,
                    Name = x.Food.Name,
                    FoodCategoryId = x.Food.FoodCategoryId,
                    Id = x.Food.Id,
                    Image = x.Food.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food.FoodCategory.Id,
                        Name = x.Food.FoodCategory.Name,
                        Status = x.Food.FoodCategory.Status
                    }
                },
                Food1 = new FoodVM()
                {
                    Description = x.Food1.Description,
                    Status = x.Food1.Status,
                    Price = x.Food1.Price,
                    Name = x.Food1.Name,
                    FoodCategoryId = x.Food1.FoodCategoryId,
                    Id = x.Food1.Id,
                    Image = x.Food1.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food1.FoodCategory.Id,
                        Name = x.Food1.FoodCategory.Name,
                        Status = x.Food1.FoodCategory.Status
                    }
                },
                Food2 = new FoodVM()
                {
                    Description = x.Food2.Description,
                    Status = x.Food2.Status,
                    Price = x.Food2.Price,
                    Name = x.Food2.Name,
                    FoodCategoryId = x.Food2.FoodCategoryId,
                    Id = x.Food2.Id,
                    Image = x.Food2.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food2.FoodCategory.Id,
                        Name = x.Food2.FoodCategory.Name,
                        Status = x.Food2.FoodCategory.Status
                    }
                },
                Food3 = new FoodVM()
                {
                    Description = x.Food3.Description,
                    Status = x.Food3.Status,
                    Price = x.Food3.Price,
                    Name = x.Food3.Name,
                    FoodCategoryId = x.Food3.FoodCategoryId,
                    Id = x.Food3.Id,
                    Image = x.Food3.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food3.FoodCategory.Id,
                        Name = x.Food3.FoodCategory.Name,
                        Status = x.Food3.FoodCategory.Status
                    }
                },
                Food4 = new FoodVM()
                {
                    Description = x.Food4.Description,
                    Status = x.Food4.Status,
                    Price = x.Food4.Price,
                    Name = x.Food4.Name,
                    FoodCategoryId = x.Food4.FoodCategoryId,
                    Id = x.Food4.Id,
                    Image = x.Food4.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food4.FoodCategory.Id,
                        Name = x.Food4.FoodCategory.Name,
                        Status = x.Food4.FoodCategory.Status
                    }
                },
                Food5 = new FoodVM()
                {
                    Description = x.Food5.Description,
                    Status = x.Food5.Status,
                    Price = x.Food5.Price,
                    Name = x.Food5.Name,
                    FoodCategoryId = x.Food5.FoodCategoryId,
                    Id = x.Food5.Id,
                    Image = x.Food5.Image,
                    FoodCategory = new FoodCategoryVM()
                    {
                        Id = x.Food5.FoodCategory.Id,
                        Name = x.Food5.FoodCategory.Name,
                        Status = x.Food5.FoodCategory.Status
                    }
                }
            })
           .OrderBy(x => x.CreateDate)
           .ToPagedList(page, pageSize);
        }

        public HotMenuVM DisplayHotMenu()
        {
            var first = _context.HotMenus
                .Where(x => x.Status == Common.CommonStatus.Active)
                .Select(x => new HotMenuVM()
                {
                    CreateDate = x.CreateDate,
                    Id = x.Id,
                    FoodId1 = x.FoodId1,
                    FoodId2 = x.FoodId2,
                    FoodId3 = x.FoodId3,
                    FoodId4 = x.FoodId4,
                    FoodId5 = x.FoodId5,
                    FoodId6 = x.FoodId6,
                    Status = x.Status,
                    Food = new FoodVM()
                    {
                        Description = x.Food.Description,
                        Price = x.Food.Price,
                        Name = x.Food.Name,
                        Id = x.Food.Id,
                        Image = x.Food.Image
                    },
                    Food1 = new FoodVM()
                    {
                        Description = x.Food1.Description,
                        Price = x.Food1.Price,
                        Name = x.Food1.Name,
                        Id = x.Food1.Id,
                        Image = x.Food1.Image
                    },
                    Food2 = new FoodVM()
                    {
                        Description = x.Food2.Description,
                        Price = x.Food2.Price,
                        Name = x.Food2.Name,
                        Id = x.Food2.Id,
                        Image = x.Food2.Image
                    },
                    Food3 = new FoodVM()
                    {
                        Description = x.Food3.Description,
                        Price = x.Food3.Price,
                        Name = x.Food3.Name,
                        Id = x.Food3.Id,
                        Image = x.Food3.Image
                    },
                    Food4 = new FoodVM()
                    {
                        Description = x.Food4.Description,
                        Price = x.Food4.Price,
                        Name = x.Food4.Name,
                        Id = x.Food4.Id,
                        Image = x.Food4.Image
                    },
                    Food5 = new FoodVM()
                    {
                        Description = x.Food5.Description,
                        Price = x.Food5.Price,
                        Name = x.Food5.Name,
                        Id = x.Food5.Id,
                        Image = x.Food5.Image
                    }
                })
           .OrderBy(x => x.CreateDate)
           .FirstOrDefault();

            if (first == null)
            {
                return CommonData.HotMenu;
            }

            return first;
        }

        public void SetActive(Guid id)
        {
            DeleteAll();
            var detail = Detail(id);
            detail.Status = Common.CommonStatus.Active;
            _context.SaveChanges();
        }
    }
}
