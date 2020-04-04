using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class BasedController : Controller
    {
        // GET: Admin/Based
        public ActionResult Index()
        {
            return View();
        }
    }
}