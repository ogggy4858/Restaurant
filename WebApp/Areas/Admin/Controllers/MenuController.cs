using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IFoodRepository _foodRepository;

        public MenuController(IMenuRepository menuRepository, IFoodRepository foodRepository)
        {
            _menuRepository = menuRepository;
            _foodRepository = foodRepository;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            var list = _menuRepository.List();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetDropdow(Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuVM model)
        {
            try
            {
                SetDropdow(Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty);
                if (ModelState.IsValid)
                {
                    _menuRepository.Create(model);
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
            var detail = _menuRepository.DetailViewModel(id);
            SetDropdow(detail.FoodId1, detail.FoodId2, detail.FoodId3, detail.FoodId4, detail.FoodId5, detail.FoodId7, detail.FoodId7, detail.FoodId8);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(MenuVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _menuRepository.Edit(model);
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
        public JsonResult SetActive(Guid id)
        {
            try
            {
                _menuRepository.SetActive(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi xảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        public SelectList GetDropdown(Guid id)
        {
            var list = _foodRepository.GetList();
            if (id == Guid.Empty)
            {
                return new SelectList(list, "Id", "Name");
            }
            return new SelectList(list, "Id", "Name", id);
        }

        public ActionResult Details(Guid id)
        {
            var detail = _menuRepository.DetailViewModel(id);
            return View(detail);
        }

        public void SetDropdow(Guid id1, Guid id2, Guid id3, Guid id4, Guid id5, Guid id6, Guid id7, Guid id8)
        {
            if (id1 == null)
                ViewBag.FoodId1 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId1 = GetDropdown(id1);

            if (id2 == null)
                ViewBag.FoodId2 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId2 = GetDropdown(id2);

            if (id3 == null)
                ViewBag.FoodId3 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId3 = GetDropdown(id3);

            if (id4 == null)
                ViewBag.FoodId4 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId4 = GetDropdown(id4);

            if (id5 == null)
                ViewBag.FoodId5 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId5 = GetDropdown(id5);

            if (id1 == null)
                ViewBag.FoodId6 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId6 = GetDropdown(id6);

            if (id1 == null)
                ViewBag.FoodId7 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId7 = GetDropdown(id7);

            if (id1 == null)
                ViewBag.FoodId8 = GetDropdown(Guid.Empty);
            else
                ViewBag.FoodId8 = GetDropdown(id8);
        }
    }
}