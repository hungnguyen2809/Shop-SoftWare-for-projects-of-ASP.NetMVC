using Models.DAO;
using ShopSoftWare.Common;
using ShopSoftWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class ADLoginController : Controller
    {
        // GET: ADLogin
        public ActionResult Login(LoginAdmin model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDao();
                var res = userDao.LoginSystem(model.username, model.password);

                if (res == 1)
                {
                    var userSession = new UserLogin();
                    var inforUser = userDao.GetUserByUsernameAndPass(model.username, model.password);
                    userSession.Username = inforUser.Username;
                    userSession.Password = inforUser.Password;
                    userSession.Name = inforUser.Name;

                    Session.Add(CommonConstants.ADMIN_SESSION, userSession);

                    return Redirect("/admin/product");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (res == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền hạn để đăng nhập vào trang này.");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không đúng.");
                }
            }

            return View("Login");
        }


        public ActionResult Logout()
        {
            Session[CommonConstants.ADMIN_SESSION] = null;
            return Redirect("/admin");
        }
    }
}