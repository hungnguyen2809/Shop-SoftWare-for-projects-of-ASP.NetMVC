using Models.DAO;
using Models.EF;
using ShopSoftWare.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class ADCategoryController : BaseController
    {
        // GET: ADCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 6)
        {
            var daoCategory = new CategoryDao();
            var model = daoCategory.GetAllPagingCategory(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult InsertCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                var daoCategory = new CategoryDao();
                var countCategory = daoCategory.CountCategory();

                if (countCategory < 9)
                {
                    model.IDCategory = "DM0" + (countCategory + 1);
                }
                else
                {
                    model.IDCategory = "DM" + (countCategory + 1);
                }

                model.CreateDate = DateTime.Now;

                var meta = FilterStringVietnamese.convertStringToNormal(model.NameCategory).Split(' ');
                model.MetaTitle = MapArrayStringToOneString.MapString(meta, '-');

                var res = daoCategory.InsertCategory(model);

                if (res == true)
                {
                    return Redirect("/admin/category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!\nVui lòng thử lại sau.");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCategory(string id)
        {
            var daoCategory = new CategoryDao();
            var model = daoCategory.GetCategoryByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            var idCategory = CommonConstants.IDCategory;
            var meta = FilterStringVietnamese.convertStringToNormal(model.NameCategory).Split(' ');
            model.MetaTitle = MapArrayStringToOneString.MapString(meta, '-');

            var res = new CategoryDao().UpdateCategory(model, idCategory);

            if(res == true)
            {
                return Redirect("/admin/category");
            }
            else
            {
                ModelState.AddModelError("", "Sửa danh mục không thành công.");
            }

            return View();
        }

        [HttpDelete]
        public ActionResult DeleteCategory(string id)
        {
            new CategoryDao().DeleteCategory(id);
            return Redirect("/admin/category");
        }

        [HttpPost]
        public JsonResult ChangeStatusCategory(string id)
        {
            var res = new CategoryDao().ChangeStatus(id);
            return Json(new { status = res });
        }
    }
}