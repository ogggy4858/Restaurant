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
                return new DesignVM()
                {
                    Quote = "Welcome",
                    Title = "Chào mừng thực khách đến với nhà hàng",
                    Content = ""
                };
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
                return new DesignVM()
                {
                    Title = "Chào mừng thực khách đến với nhà hàng",
                    Content = "Để tránh tình trạng hết bàn/bàn view sông đẹp trong những dịp quan trọng, cuối tuần, lễ tết, Khiem-Baba đã tạo ra một hệ thống tự đặt bàn trực tuyến dành cho bạn. Chỉ cần điền số điện thoại là ngay lập tức bạn đã bàn không lo hết mà còn được cả vị trí view sông đẹp. Chưa hết đâu, bạn còn nhận được giảm 10% tổng bill khi đặt trực tuyến nữa. Còn chân chừ gì mà không gọi mấy đứa cạ cứng đến chiến và thưởng thức view sông Sài Gòn có một không hai?"
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
               })
               .OrderBy(x => x.CreateDate)
               .ToList();
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
                        Title = "Mở cửa Thứ 2 - Chủ nhật",
                        Content = "10:00am - 10:00pm"
                    },
                };
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
                return new List<DesignVM>()
                {
                    new DesignVM()
                    {
                        Title = "Dịch vụ của chúng tôi",
                        Content = "Đến với nhà hàng, bạn sẽ được trải nghiệm dịch vụ tuyệt vời của chúng tôi"
                    },
                    new DesignVM()
                    {
                        Title = "Thực phẩm sạch",
                        Content = "Thực phẩm hoàn toàn từ tự nhiên, không chất bảo quản"
                    },
                    new DesignVM()
                    {
                        Title = "Ship đồ ăn nhanh",
                        Content = "Chúng tôi có một đội dân tổ riêng"
                    },
                    new DesignVM()
                    {
                        Title = "Hoạt động 24h / ngày",
                        Content = "Gọi cho chúng tôi ngay"
                    },
                };
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
                return new DesignVM()
                {
                    Title = "Hot Menu",
                    Content = "Những món ăn được nhiều người ưa chuộng nhất"
                };
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
                return new DesignVM()
                {
                    Title = "Menu",
                    Content = "Món ăn hấp dẫn của nhà hàng"
                };
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
                return new List<string>()
                {
                    "",
                    "",
                    "",
                    ""
                };
            }
            else
            {
                if(viewModel.Documents.Count == 4)
                {
                    return viewModel.Documents.Select(x => x.FileName).ToList();
                }
                return new List<string>()
                {
                    "",
                    "",
                    "",
                    ""
                };
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
