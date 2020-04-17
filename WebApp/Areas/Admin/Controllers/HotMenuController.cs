using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class HotMenuController : BasedController
    {
        private readonly IHotMenuRepository _hotMenuRepository;
        private readonly IFoodRepository _foodRepository;

        public HotMenuController(IHotMenuRepository hotMenuRepository, IFoodRepository foodRepository)
        {
            _hotMenuRepository = hotMenuRepository;
            _foodRepository = foodRepository;
        }

        // GET: Admin/Menu
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var list = _hotMenuRepository.GetList(page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetDropdow(Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotMenuVM model)
        {
            try
            {
                SetDropdow(Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty);
                if (ModelState.IsValid)
                {
                    _hotMenuRepository.Create(model);
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
            var detail = _hotMenuRepository.DetailViewModel(id);
            SetDropdow(detail.FoodId1, detail.FoodId2, detail.FoodId3, detail.FoodId4, detail.FoodId5, detail.FoodId6);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(HotMenuVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _hotMenuRepository.Edit(model);
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
                _hotMenuRepository.SetActive(id);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi xảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(Guid id)
        {
            var detail = _hotMenuRepository.DetailViewModel(id);
            return View(detail);
        }

        public void SetDropdow(Guid id1, Guid id2, Guid id3, Guid id4, Guid id5, Guid id6)
        {
            var list = _foodRepository.GetList();
            var selectList = new SelectList(list, "Id", "Name");

            if (id1 == null)
                ViewBag.FoodId1 = selectList;
            else
                ViewBag.FoodId1 = new SelectList(list, "Id", "Name", id1);

            if (id2 == null)
                ViewBag.FoodId2 = selectList;
            else
                ViewBag.FoodId2 = new SelectList(list, "Id", "Name", id2);

            if (id3 == null)
                ViewBag.FoodId3 = selectList;
            else
                ViewBag.FoodId3 = new SelectList(list, "Id", "Name", id3);

            if (id4 == null)
                ViewBag.FoodId4 = selectList;
            else
                ViewBag.FoodId4 = new SelectList(list, "Id", "Name", id4);

            if (id5 == null)
                ViewBag.FoodId5 = selectList;
            else
                ViewBag.FoodId5 = new SelectList(list, "Id", "Name", id5);

            if (id1 == null)
                ViewBag.FoodId6 = selectList;
            else
                ViewBag.FoodId6 = new SelectList(list, "Id", "Name", id6);
        }
    }
}