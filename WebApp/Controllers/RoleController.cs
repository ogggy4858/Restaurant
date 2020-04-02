using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if(_roleManager == null)
                {
                    _roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
                }
                return _roleManager;
            }
            private set
            {
                _roleManager = value;
            }
        }

        public RoleController()
        {

        }

        // GET: Role
        public async Task<ActionResult> Index()
        {
            try
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = "Admin"
                };
                await RoleManager.CreateAsync(role);
                ApplicationRole role2 = new ApplicationRole()
                {
                    Name = "Customer"
                };
                await RoleManager.CreateAsync(role2);
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}