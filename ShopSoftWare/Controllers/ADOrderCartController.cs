using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class ADOrderCartController : BaseController
    {
        // GET: ADOrderCart
        public ActionResult Index(string searchString)
        {
            var model = new OrderDao().GetListOrder(searchString, 1, 6);// page=1, pageSize = 6
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult OrderDetails(long id)
        {
            ViewBag.Order = new OrderDao().GetOrderByID(id);
            ViewBag.OrderDetails = new OrderDetailsDao().GetListOrderDetailsByIdOrder(id);
            return View();
        }
    }
}