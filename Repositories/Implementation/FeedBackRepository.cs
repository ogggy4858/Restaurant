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
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly RestaurantDbContext _context;

        public FeedBackRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Guid Create(FeedBackVM model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            FeedBack a = new FeedBack()
            {
                CreateDate = DateTime.Now,
                CustomerName = model.CustomerName,
                Id = Guid.NewGuid(),
                Message = model.Message,
                Phone = model.Phone,
                Status = Common.CommonStatus.Active,
                Title = model.Title,
                OrderIndex = GetNextOrder()
            };

            _context.FeedBacks.Add(a);
            _context.SaveChanges();

            return a.Id;
        }

        private long GetNextOrder()
        {
            var max = _context.FeedBacks.OrderByDescending(x => x.OrderIndex).FirstOrDefault();
            if (max == null)
            {
                return 1;
            }
            return max.OrderIndex + 1;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public FeedBack Detail(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            var detail = _context.FeedBacks.Find(id);
            if (detail == null)
            {
                throw new NullReferenceException();
            }
            return detail;
        }

        public FeedBackVM DetailViewModel(Guid id)
        {
            var detail = Detail(id);
            var detailView = new FeedBackVM()
            {
                CreateDate = detail.CreateDate,
                CustomerName = detail.CustomerName,
                Documents = detail.Documents.Select(x => new DocumentVM()
                {
                    DesignId = x.DesignId,
                    FeedBackId = x.FeedBackId,
                    FileName = x.FileName,
                    Id = x.Id,
                    Stauts = x.Stauts
                }).ToList(),
                Id = detail.Id,
                Message = detail.Message,
                OrderIndex = detail.OrderIndex,
                Phone = detail.Phone,
                Status = detail.Status,
                Title = detail.Title,
                ListFileName = detail.Documents.Select(x => x.FileName).ToList()
            };

            return detailView;
        }

        public IPagedList<FeedBackVM> GetList(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10)
        {
            var list = _context.FeedBacks.AsQueryable();
            if (!string.IsNullOrEmpty(searchKey))
            {
                searchKey = searchKey.Trim().ToLower();
                list = list.Where(x => x.Title.ToLower().Contains(searchKey) || x.Message.ToLower().Contains(searchKey));
            }

            if (status == null)
            {
                list = list.Where(x => x.Status != Common.CommonStatus.Delete);
            }
            else
            {
                list = list.Where(x => x.Status == status);
            }

            var viewModel = list.Select(x => new FeedBackVM()
            {
                CreateDate = x.CreateDate,
                CustomerName = x.CustomerName,
                Id = x.Id,
                Message = x.Message,
                OrderIndex = x.OrderIndex,
                Phone = x.Phone,
                Status = x.Status,
                Title = x.Title,
                ListFileName = x.Documents.Select(a => a.FileName).ToList(),
                Documents = x.Documents.Select(a => new DocumentVM()
                {
                    DesignId = a.DesignId,
                    FeedBackId = a.FeedBackId,
                    FileName = a.FileName,
                    Id = a.Id,
                    Stauts = a.Stauts
                }).ToList(),
            }).ToList();

            return viewModel.OrderBy(x => x.OrderIndex).ToPagedList(page, pageSize);
        }
    }
}
