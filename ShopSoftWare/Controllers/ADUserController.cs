using Models.DAO;
using Models.EF;
using ShopSoftWare.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ShopSoftWare.Controllers
{
    public class ADUserController : BaseController
    {
        // GET: ADUser
        public ActionResult Index(string searchString, int page = 1, int pageSize = 6)
        {
            var daoUser = new UserDao();
            var modelListuser = daoUser.GetAllPagingUser(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(modelListuser);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDao();
                var userNew = new User();
                userNew.Username = model.Username;
                userNew.Password = model.Password;
                userNew.Name = model.Name;
                userNew.Address = model.Address;
                userNew.Phone = model.Phone;
                userNew.Email = model.Email;
                userNew.CreateDate = DateTime.Now;
                userNew.ModifiDate = DateTime.Now;
                userNew.Permission = model.Permission;
                userNew.Status = model.Status;

                if (userDao.CheckUsername(model.Username.ToLower()))
                {
                    var res = userDao.InsertUser(userNew);

                    if (res == true)
                    {
                        ModelState.AddModelError("", "Thêm tài khoản thành công !\nĐang chuyển đến trang đăng nhập.");                        
                        return Redirect("/admin/user");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm tài khoản thất bại !");
                        //return Redirect("/admin/user/create");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại.");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(long id)
        {
            var model = new UserDao().GetUserByID(id);
            var userEdit = new CreateUser();
            userEdit.Username = model.Username;
            userEdit.Password = model.Password;
            userEdit.RePassword = model.Password;
            userEdit.Name = model.Name;
            userEdit.Address = model.Address;
            userEdit.Phone = model.Phone;
            userEdit.Email = model.Email;
            userEdit.Permission = model.Permission;
            return View(userEdit);
        }

        [HttpPost]
        public ActionResult EditUser(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDao();
                var userNew = new User();

                userNew.ID = model.ID;
                userNew.Username = model.Username;
                userNew.Password = model.Password;
                userNew.Name = model.Name;
                userNew.Address = model.Address;
                userNew.Phone = model.Phone;
                userNew.Email = model.Email;
                userNew.ModifiDate = DateTime.Now;
                userNew.Permission = model.Permission;

                var res = userDao.UpdateUser(userNew);
                if (res == true)
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản thành công !\nĐang chuyển đến trang đăng nhập.");                    
                    return Redirect("/admin/user");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản thất bại !");
                    //return Redirect("/admin/user/create");
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult DeleteUser(long id)
        {
            var res = new UserDao().DeleteUserByID(id);
            return Redirect("/admin/user");
        }

        [HttpPost]
        public JsonResult ChangeStatusUser(long id)
        {
            var res = new UserDao().ChangeStatus(id);
            return Json(new { status = res });
        }

    }
}