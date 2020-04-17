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
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF", ".RAW", ".JPEG" };

        public InterfaceManagerController(IDesignRepository designRepository, IDocumentRepository documentRepository)
        {
            _designRepository = designRepository;
            _documentRepository = documentRepository;
        }

        // GET: Admin/InterfaceManager
        public ActionResult Banner(int page = 1, int pageSize = 5)
        {
            ViewBag.ActionInterfaceName = "Banner";
            var list = _designRepository.GetList("Banner", page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult BannerCreate()
        {
            ViewBag.ActionInterfaceName = "Banner";
            return View();
        }

        [HttpPost]
        public ActionResult BannerCreate(DesignVM model, HttpPostedFileBase image)
        {
            ViewBag.ActionInterfaceName = "Banner";
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
            ViewBag.ActionInterfaceName = "Info1";
            var list = _designRepository.GetList("Info", true);
            return View(list);
        }

        [HttpGet]
        public ActionResult InfoCreate()
        {
            ViewBag.ActionInterfaceName = "Info1";
            return View();
        }

        [HttpPost]
        public ActionResult InfoCreate(string phone, string phoneDescription, string address, string addressDescription, string openHour, string openHourDescription)
        {
            ViewBag.ActionInterfaceName = "Info1";
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

        public ActionResult Welcome(int page = 1, int pageSize = 5)
        {
            ViewBag.ActionInterfaceName = "Welcome";
            var list = _designRepository.GetList("Welcome", page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult WelcomeCreate()
        {
            ViewBag.ActionInterfaceName = "Welcome";
            return View();
        }

        [HttpPost]
        public ActionResult WelcomeCreate(DesignVM model, HttpPostedFileBase image)
        {
            ViewBag.ActionInterfaceName = "Welcome";
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
            ViewBag.ActionInterfaceName = "Service";
            var list = _designRepository.GetList("Service", true);
            return View(list);
        }

        [HttpGet]
        public ActionResult ServiceCreate()
        {
            ViewBag.ActionInterfaceName = "Service";
            return View();
        }

        [HttpPost]
        public ActionResult ServiceCreate(string title, string description, string title1, string description1, string title2, string description2, string title3, string description3)
        {
            ViewBag.ActionInterfaceName = "Service";
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

        public ActionResult HotMenu(int page = 1, int pageSize = 10)
        {
            ViewBag.ActionInterfaceName = "Menu1";
            var list = _designRepository.GetList("HotMenu", page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult HotMenuCreate()
        {
            ViewBag.ActionInterfaceName = "Menu1";
            return View();
        }

        [HttpPost]
        public ActionResult HotMenuCreate(DesignVM model)
        {
            ViewBag.ActionInterfaceName = "Menu1";
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

        public ActionResult Menu(int page = 1, int pageSize = 10)
        {
            ViewBag.ActionInterfaceName = "Menu2";
            var list = _designRepository.GetList("Menu", page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult MenuCreate()
        {
            ViewBag.ActionInterfaceName = "Menu2";
            return View();
        }

        [HttpPost]
        public ActionResult MenuCreate(DesignVM model)
        {
            ViewBag.ActionInterfaceName = "Menu2";
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

        public ActionResult Image(int page = 1, int pageSize = 5)
        {
            ViewBag.ActionInterfaceName = "Image";
            var list = _designRepository.GetList("Image", page, pageSize);
            return View(list);
        }

        [HttpGet]
        public ActionResult ImageCreate()
        {
            ViewBag.ActionInterfaceName = "Image";
            return View();
        }

        [HttpPost]
        public ActionResult ImageCreate(HttpPostedFileBase image1, HttpPostedFileBase image2,
            HttpPostedFileBase image3, HttpPostedFileBase image4,
            HttpPostedFileBase image5, HttpPostedFileBase image6,
            HttpPostedFileBase image7, HttpPostedFileBase image8)
        {
            ViewBag.ActionInterfaceName = "Image";
            try
            {
                if (image1 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 1");
                }
                if (image2 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 2");
                }
                if (image3 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 3");
                }
                if (image4 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 4");
                }
                if (image5 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 5");
                }
                if (image6 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 6");
                }
                if (image7 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 7");
                }
                if (image8 == null)
                {
                    ModelState.AddModelError("", "Bạn phải chọn hình ảnh 8");
                }

                if (image1 != null && image2 != null && image3 != null && image4 != null
                    && image5 != null && image6 != null && image7 != null && image8 != null)
                {
                    var imageId = _designRepository.Create(new DesignVM()
                    {
                        Content = "Content Images"
                    }, "Image");
                    var fileName1 = SaveImage(image1);
                    var fileName2 = SaveImage(image2);
                    var fileName3 = SaveImage(image3);
                    var fileName4 = SaveImage(image4);
                    var fileName5 = SaveImage(image5);
                    var fileName6 = SaveImage(image6);
                    var fileName7 = SaveImage(image7);
                    var fileName8 = SaveImage(image8);

                    var listFileName = new List<string>();
                    listFileName.Add(fileName1);
                    listFileName.Add(fileName2);
                    listFileName.Add(fileName3);
                    listFileName.Add(fileName4);
                    listFileName.Add(fileName5);
                    listFileName.Add(fileName6);
                    listFileName.Add(fileName7);
                    listFileName.Add(fileName8);

                    _documentRepository.CreateForDesign(listFileName, imageId);
                    return RedirectToAction("Image");
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, vui lòng thử lại sau");
                return View();
            }
        }

        public ActionResult SynthesizeInfo()
        {
            ViewBag.ActionInterfaceName = "Info2";
            var list = _designRepository.GetList("SynthesizeInfo", true);
            return View(list);
        }

        [HttpGet]
        public ActionResult SynthesizeInfoCreate()
        {
            ViewBag.ActionInterfaceName = "Info2";
            return View();
        }

        [HttpPost]
        public ActionResult SynthesizeInfoCreate(string title, string description, string title1, string description1, string title2, string description2, HttpPostedFileBase image)
        {
            ViewBag.ActionInterfaceName = "Info2";
            ViewBag.TitleMain = title;
            ViewBag.DescriptionMain = description;
            ViewBag.Title1 = title1;
            ViewBag.Description1 = description1;
            ViewBag.Title2 = title2;
            ViewBag.Description2 = description2;

            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(title1) || string.IsNullOrWhiteSpace(description1) ||
                    string.IsNullOrWhiteSpace(title2) || string.IsNullOrWhiteSpace(description2))
                {
                    ModelState.AddModelError("", "Dữ liệu không được để trống");
                    return View();
                }

                _designRepository.DeleteByCategory("SynthesizeInfo");
                var id1 = _designRepository.Create(new DesignVM()
                {
                    Title = title,
                    Content = description
                }, "SynthesizeInfo", false);
                var id2 = _designRepository.Create(new DesignVM()
                {
                    Title = title1,
                    Content = description1
                }, "SynthesizeInfo", false);
                var id3 = _designRepository.Create(new DesignVM()
                {
                    Title = title2,
                    Content = description2
                }, "SynthesizeInfo", false);

                if (image != null)
                {
                    var fileName = SaveImage(image);
                    _documentRepository.CreateForDesign(fileName, id1);
                    _documentRepository.CreateForDesign(fileName, id2);
                    _documentRepository.CreateForDesign(fileName, id3);
                }

                return RedirectToAction("SynthesizeInfo");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, vui lòng thử lại sau");
                return View();
            }
        }

        public ActionResult FoodCategory(int page = 1, int pageSize = 5)
        {
            ViewBag.ActionInterfaceName = "FoodCategory";
            var list = _designRepository.GetList("FoodCategory", page, pageSize, null);
            return View(list);
        }

        [HttpGet]
        public ActionResult FoodCategoryCreate()
        {
            ViewBag.ActionInterfaceName = "FoodCategory";
            return View();
        }

        [HttpPost]
        public ActionResult FoodCategoryCreate(HttpPostedFileBase image)
        {
            ViewBag.ActionInterfaceName = "FoodCategory";
            try
            {
                if (image != null)
                {
                    ModelState.AddModelError("", "Hình ảnh là bắt buộc");
                }

                var designId = _designRepository.Create(new DesignVM()
                {
                    Content = "FoodCategoryCreate"
                }, "FoodCategory");

                string fileName = SaveImage(image);
                _documentRepository.CreateForDesign(fileName, designId);
                return RedirectToAction("FoodCategory");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, vui lòng thử lại sau");
                return View();
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