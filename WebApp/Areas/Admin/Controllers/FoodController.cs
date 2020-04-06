using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class FoodController : BasedController
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodCategoryRepository _foodCategoryRepository;

        public FoodController(IFoodRepository foodRepository, IFoodCategoryRepository foodCategoryRepository)
        {
            _foodRepository = foodRepository;
            _foodCategoryRepository = foodCategoryRepository;
        }

        // GET: Admin/Food
        public ActionResult Index(string searchKey = "", bool? status = null, int page = 1, int pageSize = 10)
        {
            var list = _foodRepository.GetList(searchKey, status, page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FoodCategoryId = SetDropdown(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodVM model, HttpPostedFileBase image)
        {
            try
            {
                ViewBag.FoodCategoryId = SetDropdown(null);
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        model.Image = SaveImage(image);
                    }
                    _foodRepository.Create(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var detail = _foodRepository.DetailViewModel(id);
            ViewBag.FoodCategoryId = SetDropdown(detail.FoodCategoryId);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(FoodVM model, HttpPostedFileBase image)
        {
            try
            {
                ViewBag.FoodCategoryId = SetDropdown(model.FoodCategoryId);
                CheckIvalid(ModelState);
                if (ModelState.IsValid == true || CheckIvalid(ModelState))
                {
                    var detail = _foodRepository.DetailViewModel(model.Id);
                    if (image != null)
                    {
                        // RemoveImage(detail.Image);
                        model.Image = SaveImage(image);
                    }
                    else
                    {
                        model.Image = detail.Image;
                    }
                    _foodRepository.Edit(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            try
            {
                _foodRepository.Delete(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        private string SaveImage(HttpPostedFileBase image)
        {
            var name = Path.GetFileName(image.FileName);
            string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
            image.SaveAs(path);
            return image.FileName;
        }

        private void RemoveImage(string fileName)
        {
            string path = Server.MapPath("~/Areas/Admin/Libraries/images/" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        private bool CheckIvalid(ModelStateDictionary state)
        {
            if (state == null)
                return false;

            int temp = 0;
            foreach(var item in state.Values)
            {
                if(temp == 4 && item.Errors.Count > 0)
                {
                    return true;
                }
                temp++;
            }

            return false;
        }

        public SelectList SetDropdown(long? id)
        {
            var list = _foodCategoryRepository.DropdownList();
            if (id == null)
            {
                return new SelectList(list, "Id", "Name");
            }
            else
            {
                return new SelectList(list, "Id", "Name", id);
            }
        }
    }
}