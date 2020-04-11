
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class DesignCategoryController : BasedController
    {
        private readonly IDesignCategoryRepository _designCategoryRepository;

        public DesignCategoryController(IDesignCategoryRepository designCategoryRepository)
        {
            _designCategoryRepository = designCategoryRepository;
        }

        // GET: Admin/DesignCategory
        public ActionResult Index()
        {
            var list = _designCategoryRepository.GetList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesignCategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _designCategoryRepository.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var detail = _designCategoryRepository.DetailViewModel(id);
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DesignCategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _designCategoryRepository.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            try
            {
                if(id == 0)
                {
                    return Json(new { Staus = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
                }
                _designCategoryRepository.Delete(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Staus = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}