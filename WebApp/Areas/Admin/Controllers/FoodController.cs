using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class FoodController : BasedController
    {
        private readonly IFoodCategoryRepository _foodCategoryRepository;

        public FoodController(IFoodCategoryRepository foodCategoryRepository)
        {
            _foodCategoryRepository = foodCategoryRepository;
        }

        // GET: Admin/Food
        public ActionResult Index(string searchKey = "", bool? status = null, int page = 1, int pageSize = 20)
        {
            var list = _foodCategoryRepository.GetList(searchKey, status, page, pageSize);
            return View(list);
        }
    }
}