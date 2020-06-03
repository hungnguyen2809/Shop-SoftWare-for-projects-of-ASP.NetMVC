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
    public class ADProductController : BaseController
    {
        // GET: ADProduct
        public ActionResult Index(string searchString, int page = 1, int pageSize = 6)
        {
            var daoProduct = new ProductDao();
            var model = daoProduct.GetAllPagingProduct(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewbag(string id = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDCategory = new SelectList(dao.GetListCategory(), "IDCategory", "NameCategory", id);
        }

        [HttpGet]
        public ActionResult InsertProduct()
        {
            SetViewbag();
            return View();
        }

        [HttpPost]
        public ActionResult InsertProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                var daoProduct = new ProductDao();
                model.CreateDate = DateTime.Now;
                var count = daoProduct.GetCountProduct();

                if (count < 9)
                {
                    model.IDProduct = "SP0" + (count + 1);
                }
                else if( count >= 10)
                {
                    model.IDProduct = "SP" + (count + 1);
                }
                
                var res = daoProduct.InsertProduct(model);

                if(res == true)
                {
                    return Redirect("/admin/product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công !");
                    //return Redirect("/admin/product/insert");
                }
            }
            SetViewbag();
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(string id)
        {
            var daoProduct = new ProductDao();
            var product = daoProduct.GetProductByID(id);
            SetViewbag(product.IDCategory);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product entity)
        {
            if (ModelState.IsValid)
            {
               
                var res = new ProductDao().UpdateProduct(entity, CommonConstants.IDProduct);

                if(res == true)
                {
                    return Redirect("/admin/product");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công.");                  
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(string id)
        {
            new ProductDao().DeleteProductByID(id);
            return Redirect("/admin/product");
        }

    }
}