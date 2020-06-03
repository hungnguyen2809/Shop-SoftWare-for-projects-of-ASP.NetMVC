using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSoftWare.Models
{
    public class LoginAdmin
    {

        [Required(ErrorMessage ="Nhập tài khoản người dùng !")]
        public string username { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu người dùng !")]
        public string password { get; set; }
    }
}