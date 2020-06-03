using Models.DAO;
using ShopSoftWare.Common;
using ShopSoftWare.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class USHomeController : Controller
    {
        // GET: USHome
        public ActionResult Index()
        {
            var dao = new ProductDao();
            ViewBag.ListWin = dao.ListProductForHome("DM01");
            ViewBag.ListOffice = dao.ListProductForHome("DM02");
            ViewBag.ListGame = dao.ListProductForHome("DM03");
            ViewBag.ListVirus = dao.ListProductForHome("DM04");
            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var modelFooter = new FooterDao().GetFooterByID(1);
            return PartialView(modelFooter);
        }

        [ChildActionOnly]
        public ActionResult Cart()
        {
            var cartSession = Session[CommonConstants.CART_SECSSION];
            var listCart = new List<CartItem>();
            if (cartSession != null)
            {
                listCart = (List<CartItem>)cartSession;
            }

            var customerSession = Session[CommonConstants.CUSTOMER_SECSION];
            var customer = new Customer();
            if(customerSession != null)
            {
                customer = (Customer)customerSession;
            }

            ViewBag.InforCustomer = customer;

            return PartialView(listCart);
        }
    }
}