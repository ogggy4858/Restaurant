using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Repositories.Implementation
{
    public class DesignRepository : IDesignRepository
    {
        private readonly RestaurantDbContext _context;

        public DesignRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Guid Create(DesignVM model, string categoryName, bool isDelete = true)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var designCategoryId = GetDesignCategoryIdByName(categoryName);
            if (isDelete)
            {
                DeleteByCategory(designCategoryId);
            }
            var en = new Design()
            {
                Content = model.Content,
                CreateDate = DateTime.Now,
                DesignCategoryId = designCategoryId,
                Id = Guid.NewGuid(),
                Quote = model.Quote,
                Status = Common.CommonStatus.Active,
                Title = model.Title
            };

            _context.Designs.Add(en);
            _context.SaveChanges();

            return en.Id;
        }

        public void DeleteByCategory(long designCategoryId)
        {
            var list = _context.Designs.Where(x => x.DesignCategory.Id == designCategoryId).ToList();
            foreach (var item in list)
            {
                item.Status = Common.CommonStatus.Delete;
            }
            _context.SaveChanges();
        }

        public void DeleteByCategory(string designCategoryName)
        {
            var list = _context.Designs.Where(x => x.DesignCategory.Name == designCategoryName).ToList();
            foreach (var item in list)
            {
                item.Status = Common.CommonStatus.Delete;
            }
            _context.SaveChanges();
        }

        public List<DesignVM> GetList(string categoryName, bool? status = null)
        {
            var listQuery = _context.Designs
                .Where(x => x.DesignCategory.Name == categoryName);

            if(status != null)
            {
                listQuery = listQuery.Where(x => x.Status == status);
            }

            return listQuery.Select(x => new DesignVM()
                {
                    Content = x.Content,
                    CreateDate = x.CreateDate,
                    DesignCategoryId = x.DesignCategoryId,
                    Id = x.Id,
                    Quote = x.Quote,
                    Status = x.Status,
                    Title = x.Title,
                    DesignCategory = new DesignCategoryVM()
                    {
                        Status = x.DesignCategory.Status,
                        Id = x.DesignCategory.Id,
                        Name = x.DesignCategory.Name
                    },
                    Documents = x.Documents.Select(a => new DocumentVM()
                    {
                        Id = a.Id,
                        DesignId = a.DesignId,
                        FileName = a.FileName,
                        FeedBackId = a.FeedBackId,
                        Stauts = a.Stauts
                    }).ToList()
                }).ToList();
        }

        public DesignVM DisplayBanner(string categoryName)
        {
            var viewModel = _context.Designs
                .Where(x => x.DesignCategory.Name == categoryName && x.Status == Common.CommonStatus.Active)
                .Select(x => new DesignVM()
                {
                    Content = x.Content,
                    CreateDate = x.CreateDate,
                    DesignCategoryId = x.DesignCategoryId,
                    Id = x.Id,
                    Quote = x.Quote,
                    Status = x.Status,
                    Title = x.Title,
                    DesignCategory = new DesignCategoryVM()
                    {
                        Status = x.DesignCategory.Status,
                        Id = x.DesignCategory.Id,
                        Name = x.DesignCategory.Name
                    },
                    Documents = x.Documents.Select(a => new DocumentVM()
                    {
                        Id = a.Id,
                        DesignId = a.DesignId,
                        FileName = a.FileName,
                        FeedBackId = a.FeedBackId,
                        Stauts = a.Stauts
                    }).ToList()
                }).FirstOrDefault();
            if (viewModel == null)
            {
                return new DesignVM()
                {
                    Quote = "Welcome",
                    Title = "Chào mừng thực khách đến với nhà hàng",
                    Content = ""
                };
            }

            return viewModel;
        }

        public List<DesignVM> DisplayInfo(string categoryName)
        {
            var viewModel = _context.Designs
               .Where(x => x.DesignCategory.Name == categoryName && x.Status == Common.CommonStatus.Active)
               .Select(x => new DesignVM()
               {
                   Content = x.Content,
                   CreateDate = x.CreateDate,
                   DesignCategoryId = x.DesignCategoryId,
                   Id = x.Id,
                   Quote = x.Quote,
                   Status = x.Status,
                   Title = x.Title,
                   DesignCategory = new DesignCategoryVM()
                   {
                       Status = x.DesignCategory.Status,
                       Id = x.DesignCategory.Id,
                       Name = x.DesignCategory.Name
                   },
                   Documents = x.Documents.Select(a => new DocumentVM()
                   {
                       Id = a.Id,
                       DesignId = a.DesignId,
                       FileName = a.FileName,
                       FeedBackId = a.FeedBackId,
                       Stauts = a.Stauts
                   }).ToList()
               }).ToList();
            if (viewModel == null)
            {
                return new List<DesignVM>()
                {
                    new DesignVM()
                    {
                        Title = "0999999113",
                        Content = "Call me baby"
                    },
                    new DesignVM()
                    {
                        Title = "127 Hòa Mã",
                        Content = "Quận Sao Hỏa, Hà Nội, Việt Nam"
                    },
                    new DesignVM()
                    {
                        Title = "Open Monday-Sunday",
                        Content = "10:00am - 10:00pm"
                    },
                };
            }
            return viewModel;
        }

        private long GetDesignCategoryIdByName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentNullException();
            }

            var detail = _context.DesignCategories.FirstOrDefault(x => x.Name == categoryName);

            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail.Id;
        }


    }
}
