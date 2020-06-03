using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class USProductController : Controller
    {
        public ActionResult KeyWindow(int page = 1, int pageSize = 6)
        {
            var dao = new ProductDao();
            var listProductWindows = dao.GetListPagingProductForCategory("DM01", page, pageSize);

            List<Product> listProductReferences = new List<Product>();         
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM02"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM03"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM04"));
            ViewBag.ProductReferences = listProductReferences;
            return View(listProductWindows);
        }

        public ActionResult KeyOffice(int page = 1, int pageSize = 6)
        {
            var dao = new ProductDao();
            var listProductOffice = dao.GetListPagingProductForCategory("DM02", page, pageSize);
            List<Product> listProductReferences = new List<Product>();
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM01"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM03"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM04"));
            ViewBag.ProductReferences = listProductReferences;
            return View(listProductOffice);
        }

        public ActionResult KeyGame(int page = 1, int pageSize = 6)
        {
            var dao = new ProductDao();
            var listProductOffice = dao.GetListPagingProductForCategory("DM03", page, pageSize);
            List<Product> listProductReferences = new List<Product>();
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM01"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM02"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM04"));
            ViewBag.ProductReferences = listProductReferences;
            return View(listProductOffice);
        }

        public ActionResult KeyVirus(int page = 1, int pageSize = 6)
        {
            var dao = new ProductDao();
            var listProductOffice = dao.GetListPagingProductForCategory("DM04", page, pageSize);
            List<Product> listProductReferences = new List<Product>();
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM01"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM02"));
            listProductReferences.Add(dao.GetOneProductForIDCategory("DM03"));
            ViewBag.ProductReferences = listProductReferences;
            return View(listProductOffice);
        }

        [HttpGet]
        public ActionResult DetailsProduct(string id)
        {
            var detailsProduct = new ProductDao().GetProductByID(id);
            return View(detailsProduct);
        }
    }
}