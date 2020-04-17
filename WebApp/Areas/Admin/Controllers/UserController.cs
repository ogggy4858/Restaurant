using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class UserController : BasedController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = _userRepository.GetList(page, pageSize);
            return View(list);
        }

        [HttpPost]
        public JsonResult RemoveAdmin(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
                }
                _userRepository.RemoveRole(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddAdmin(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
                }
                _userRepository.SetRole(id, Common.CommonStatus.AdminRole);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}