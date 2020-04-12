using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class InterfaceManagerController : BasedController
    {
        private readonly IDesignRepository _designRepository;
        private readonly IDocumentRepository _documentRepository;
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF" };

        public InterfaceManagerController(IDesignRepository designRepository, IDocumentRepository documentRepository)
        {
            _designRepository = designRepository;
            _documentRepository = documentRepository;
        }

        // GET: Admin/InterfaceManager
        public ActionResult Banner()
        {
            var list = _designRepository.GetList("Banner");
            return View(list);
        }

        [HttpGet]
        public ActionResult BannerCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BannerCreate(DesignVM model, HttpPostedFileBase image)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Quote))
                {
                    ModelState.AddModelError("", "Welcome không được để trống");
                    return View(model);
                }

                if (string.IsNullOrEmpty(model.Title))
                {
                    ModelState.AddModelError("", "Tiêu đề không được để trống");
                    return View(model);
                }

                if (string.IsNullOrEmpty(model.Content))
                {
                    ModelState.AddModelError("", "Nội dung không được để trống");
                    return View(model);
                }

                if (image == null)
                {
                    ModelState.AddModelError("", "Hình ảnh không được để trống");
                    return View(model);
                }

                if (model.Quote.Length > 50)
                {
                    ModelState.AddModelError("", "Welcome không được quá 50 ký tự");
                    return View(model);
                }

                if (model.Title.Length > 50)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá 200 ký tự");
                    return View(model);
                }

                var bannerId = _designRepository.Create(model, "Banner");
                string fileName = SaveImage(image);
                _documentRepository.CreateForDesign(fileName, bannerId);
                return RedirectToAction("Banner");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, Vui lòng thử lại sau");
                return View(model);
            }
        }

        public ActionResult Info()
        {
            var list = _designRepository.GetList("Info", true);
            return View(list);
        }

        [HttpGet]
        public ActionResult InfoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InfoCreate(string phone, string phoneDescription, string address, string addressDescription, string openHour, string openHourDescription)
        {
            ViewBag.Phone = phone;
            ViewBag.PhoneDescription = phoneDescription;
            ViewBag.Address = address;
            ViewBag.AddressDescription = addressDescription;
            ViewBag.OpenHour = openHour;
            ViewBag.OpenHourDescription = openHourDescription;

            try
            {
                if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(phoneDescription) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(addressDescription) || string.IsNullOrWhiteSpace(openHour) || string.IsNullOrWhiteSpace(openHourDescription))
                {
                    ModelState.AddModelError("", "Dữ liệu không được để trống");
                    return View();
                }

                if (phone.Length > 200)
                {
                    ModelState.AddModelError("", "Số điện thoại không được quá dài");
                    return View();
                }


                if (address.Length > 200)
                {
                    ModelState.AddModelError("", "Địa chỉ không được quá dài");
                    return View();
                }


                if (openHour.Length > 200)
                {
                    ModelState.AddModelError("", "Giờ mở của không được quá dài");
                    return View();
                }

                _designRepository.DeleteByCategory("Info");
                _designRepository.Create(new DesignVM() { Title = phone, Content = phoneDescription }, "Info", false);
                _designRepository.Create(new DesignVM() { Title = address, Content = addressDescription }, "Info", false);
                _designRepository.Create(new DesignVM() { Title = openHour, Content = openHourDescription }, "Info", false);

                return RedirectToAction("Info");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, vui òng thử lại sau");
                return View();
            }
        }

        public ActionResult Welcome()
        {
            var list = _designRepository.GetList("Welcome");
            return View(list);
        }

        [HttpGet]
        public ActionResult WelcomeCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WelcomeCreate(DesignVM model, HttpPostedFileBase image)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title))
                {
                    ModelState.AddModelError("", "Tiêu đề không được để trống");
                    return View(model);
                }

                if (string.IsNullOrEmpty(model.Content))
                {
                    ModelState.AddModelError("", "Nội dung không được để trống");
                    return View(model);
                }

                if (image == null)
                {
                    ModelState.AddModelError("", "Hình ảnh không được để trống");
                    return View(model);
                }

                if (model.Title.Length > 50)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá 200 ký tự");
                    return View(model);
                }

                var bannerId = _designRepository.Create(model, "Welcome", true);
                string fileName = SaveImage(image);
                _documentRepository.CreateForDesign(fileName, bannerId);
                return RedirectToAction("Welcome");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, Vui lòng thử lại sau");
                return View(model);
            }
        }

        public ActionResult Service()
        {
            var list = _designRepository.GetList("Service", true);
            return View(list);
        }

        [HttpGet]
        public ActionResult ServiceCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServiceCreate(string title, string description, string title1, string description1, string title2, string description2, string title3, string description3)
        {
            ViewBag.TitleMain = title;
            ViewBag.DescriptionMain = description;
            ViewBag.Title1 = title1;
            ViewBag.Description1 = description1;
            ViewBag.Title2 = title2;
            ViewBag.Description2 = description2;
            ViewBag.Title3 = title3;
            ViewBag.Description3 = description3;

            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(title1) || string.IsNullOrWhiteSpace(description1) || string.IsNullOrWhiteSpace(title2) || string.IsNullOrWhiteSpace(description2) || string.IsNullOrWhiteSpace(title3) || string.IsNullOrWhiteSpace(description3))
                {
                    ModelState.AddModelError("", "Dữ liệu không được để trống");
                    return View();
                }

                if (title.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá dài");
                    return View();
                }


                if (title1.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề 1 không được quá dài");
                    return View();
                }

                if (title2.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề 2 không được quá dài");
                    return View();
                }

                if (title3.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề 3 không được quá dài");
                    return View();
                }

                _designRepository.DeleteByCategory("Service");
                _designRepository.Create(new DesignVM() { Title = title, Content = description }, "Service", false);
                _designRepository.Create(new DesignVM() { Title = title1, Content = description1 }, "Service", false);
                _designRepository.Create(new DesignVM() { Title = title2, Content = description2 }, "Service", false);
                _designRepository.Create(new DesignVM() { Title = title3, Content = description3 }, "Service", false);

                return RedirectToAction("Service");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, vui òng thử lại sau");
                return View();
            }
        }

        public ActionResult HotMenu()
        {
            var list = _designRepository.GetList("HotMenu");
            return View(list);
        }

        [HttpGet]
        public ActionResult HotMenuCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HotMenuCreate(DesignVM model)
        {
            try
            {
                if (model == null)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                    return View(model);
                }

                if (string.IsNullOrWhiteSpace(model.Title))
                {
                    ModelState.AddModelError("", "Tiêu đề không được để trống");
                    return View(model);
                }

                if (string.IsNullOrWhiteSpace(model.Content))
                {
                    ModelState.AddModelError("", "Nội dung không được để trống");
                    return View(model);
                }

                if (model.Title.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá dài");
                    return View(model);
                }

                _designRepository.Create(model, "HotMenu");
                return RedirectToAction("HotMenu");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                return View(model);
            }
        }

        public ActionResult Menu()
        {
            var list = _designRepository.GetList("Menu");
            return View(list);
        }


        [HttpGet]
        public ActionResult MenuCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MenuCreate(DesignVM model)
        {
            try
            {
                if (model == null)
                {
                    ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                    return View(model);
                }

                if (string.IsNullOrWhiteSpace(model.Title))
                {
                    ModelState.AddModelError("", "Tiêu đề không được để trống");
                    return View(model);
                }

                if (string.IsNullOrWhiteSpace(model.Content))
                {
                    ModelState.AddModelError("", "Nội dung không được để trống");
                    return View(model);
                }

                if (model.Title.Length > 200)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá dài");
                    return View(model);
                }

                _designRepository.Create(model, "Menu");
                return RedirectToAction("Menu");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại sau");
                return View(model);
            }
        }


        [HttpPost]
        public JsonResult Active(Guid id, string categoryName)
        {
            try
            {
                if (id == null || id == Guid.Empty)
                {
                    return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
                }
                _designRepository.SetActive(id, categoryName);
                return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = "Có lỗi sảy ra, vui lòng thử lại sau" }, JsonRequestBehavior.AllowGet);
            }
        }

        private List<string> SaveImage(HttpPostedFileBase[] file)
        {
            List<string> listFileName = new List<string>();
            foreach (var item in file)
            {
                var name = Path.GetFileName(item.FileName);
                if (ImageExtensions.Contains(Path.GetExtension(name).ToUpperInvariant()))
                {
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
                    item.SaveAs(path);
                    listFileName.Add(item.FileName);
                }
            }
            return listFileName;
        }

        private string SaveImage(HttpPostedFileBase file)
        {
            var name = Path.GetFileName(file.FileName);
            if (ImageExtensions.Contains(Path.GetExtension(name).ToUpperInvariant()))
            {
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
                file.SaveAs(path);
            }
            return file.FileName;
        }
    }
}