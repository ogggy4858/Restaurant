using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class FoodCategoryController : Controller
    {
        private readonly IFoodCategoryRepository _foodCategoryRepository;

        public FoodCategoryController(IFoodCategoryRepository foodCategoryRepository)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }

        // GET: Admin/FoodCategory
        public ActionResult Index(string searchKey = "", bool? status = null, int page = 1, int pageSize = 20)
        {
            var list = _foodCategoryRepository.GetList(searchKey, status, page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodCategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _foodCategoryRepository.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại");
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            try
            {
                _foodCategoryRepository.Delete(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Status = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}