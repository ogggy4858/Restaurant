using Models;
using Repositories.Interfaces;
using Repositories.StaticData;
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

            if (status != null)
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
            })
                .OrderBy(x => x.CreateDate)
                .ToList();
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
                return CommonData.DisplayBanner;
            }

            return viewModel;
        }

        public DesignVM DisplayWelcome(string categoryName)
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
                return CommonData.DisplayWelcome;
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
               })
               .OrderBy(x => x.CreateDate)
               .ToList();
            if (viewModel == null)
            {
                return CommonData.DisplayInfo;
            }

            if(viewModel.Count == 0 || viewModel.Count != 3)
            {
                return CommonData.DisplayInfo;
            }

            return viewModel;
        }

        public List<DesignVM> DisplayService(string categoryName)
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
               })
               .OrderBy(x => x.CreateDate)
               .ToList();
            if (viewModel == null)
            {
                return CommonData.DisplayService;
            }

            if(viewModel.Count == 0 || viewModel.Count != 4)
            {
                return CommonData.DisplayService;
            }

            return viewModel;
        }

        public DesignVM DisplayHotMenu(string categoryName)
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
                return CommonData.DisplayHotMenu;
            }

            return viewModel;
        }

        public DesignVM DisplayMenu(string categoryName)
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
                return CommonData.DisplayMenu;
            }

            return viewModel;
        }

        public List<string> DisplayImage(string categoryName)
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
                return CommonData.DisplayImage;
            }
            else
            {
                if(viewModel.Documents.Count == 8)
                {
                    return viewModel.Documents.Select(x => x.FileName).ToList();
                }
                return CommonData.DisplayImage;
            }
        }

        private Design Detail(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            var detail = _context.Designs.Find(id);

            if (detail == null)
            {
                throw new NullReferenceException();
            }

            return detail;
        }

        public void SetActive(Guid designId, string categoryName)
        {
            DeleteByCategory(categoryName);
            var detail = Detail(designId);
            detail.Status = Common.CommonStatus.Active;
            _context.SaveChanges();
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
