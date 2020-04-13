using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class BasedController : Controller
    {
        private readonly IUserRepository _userRepository;
        public BasedController()
        {
            _userRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAdmin = _userRepository.IsAdmin(User.Identity.Name);
            if (Request.IsAuthenticated == false || isAdmin == false)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Viewer", action = "NotFoundPage", Area = "" }));
            }
            base.OnActionExecuting(filterContext);
        }

        public ActionResult NotFountPage()
        {
            return View();
        }
    }
}