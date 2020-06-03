using Models.DAO;
using Models.EF;
using ShopSoftWare.Common;
using ShopSoftWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSoftWare.Controllers
{
    public class USAccountController : Controller
    {
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(string username, string name, string pass, string address, string phone, string email)
        {
            var daoUser = new UserDao();
            if (daoUser.CheckUsername(username))
            {
                var customer = new User();
                customer.Username = username;
                customer.Name = name;
                customer.Password = pass;
                customer.Address = address;
                customer.Phone = phone;
                customer.Email = email;
                customer.CreateDate = DateTime.Now;
                customer.Status = true;
                customer.Permission = false;

                var res = daoUser.InsertUser(customer);

                if (res == true)
                {
                    return Redirect("/dang-nhap");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản thất bại !\nHãy thử lại nếu còn gặp tình trạng này hãy liên hệ với chúng tôi");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tên tài khoản đã tồn tại.");
            }

            return View();
        }

        public ActionResult LoginCustomer(LoginCustomer model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDao();
                var res = userDao.LoginCustomer(model.username, model.password);

                if (res == 1)
                {
                    var userSession = new Customer();
                    var inforUser = userDao.GetUserByUsernameAndPass(model.username, model.password);
                    userSession.Username = inforUser.Username;
                    userSession.Password = inforUser.Password;
                    userSession.Name = inforUser.Name;
                    userSession.Address = inforUser.Address;
                    userSession.Phone = inforUser.Phone;
                    userSession.Email = inforUser.Email;
                    Session.Add(CommonConstants.CUSTOMER_SECSION, userSession);

                    return Redirect("/trang-chu");
                }
                else if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (res == -2)
                {
                    ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không đúng.");
                }
            }
            return View();
        }

        public ActionResult LogoutCustomer()
        {
            Session[CommonConstants.CUSTOMER_SECSION] = null;
            return Redirect("/trang-chu");
        }
    }
}