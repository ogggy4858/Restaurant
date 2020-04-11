using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class FeedBackController : BasedController
    {
        private readonly IFeedBackRepository _feedBackRepository;

        public FeedBackController(IFeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }

        // GET: Admin/FeedBack
        public ActionResult Index(string searchKey = "", byte? status = null, int page = 1, int pageSize = 10)
        {
            bool? statusBussi = null;
            if (status == 1)
            {
                statusBussi = true;
            }
            else if(status == 0)
            {
                statusBussi = false;
            }
            
            var list = _feedBackRepository.GetList(searchKey, statusBussi, page, pageSize);
            ViewBag.SearchKey = searchKey;
            ViewBag.Status = status;
            return View(list);
        }

        [HttpPost]
        public JsonResult DisableFeedBack(Guid id)
        {
            try
            {
                if(id == null || id == Guid.Empty)
                {
                    return Json(new { Status = false, Message = "Có lỗi xảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
                }
                _feedBackRepository.Delete(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi xảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(Guid id)
        {
            try
            {
                var detail = _feedBackRepository.DetailViewModel(id);
                return View(detail);
            }
            catch(Exception ex)
            {
                return View("ErrorView");
            }
        }
    }
}