using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class ADFooterController : BaseController
    {
        // GET: ADFooter
        public ActionResult Index()
        {
            var model = new FooterDao().GetFooterByID(1);
            return View(model);
        }

        [HttpGet]
        public ActionResult EditFooter(long id)
        {
            var model = new FooterDao().GetFooterByID(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditFooter(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var res = new FooterDao().UpdateFooter(footer);

                if(res == true)
                {
                    return Redirect("/admin/footer");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa không thành công.");
                }
            }
            return View();
        }
    }
}