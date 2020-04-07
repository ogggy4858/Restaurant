using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IFeedBackRepository _feedBackRepository;

        public FeedBackController(IFeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }

        // GET: Admin/FeedBack
        public ActionResult Index(string searchKey = "", bool? status = null, int page = 1, int pageSize = 2)
        {
            var list = _feedBackRepository.GetList(searchKey, status, page, pageSize);
            return View(list);
        }
    }
}