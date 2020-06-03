using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSoftWare.Common
{
    public class CreateUser
    {
        [Key]
        [ScaffoldColumn(false)]
        public long ID { get; set; }


        [Display(Name ="Tên tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tài khoản !")]
        [StringLength(20, ErrorMessage ="Tài khoản có độ từ  6-20 ký tự", MinimumLength = 5)]
        
        public string Username { get; set; }


        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn chưa điền tên !")]
        [StringLength(20, ErrorMessage = "Tên người dùng tối đa 50 ký tự", MinimumLength = 1)]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu !")]
        [StringLength(20, ErrorMessage = "Mật khẩu có độ dài từ 6-20 ký tự", MinimumLength = 5)]
        
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu !")]
        [StringLength(20, ErrorMessage = "Mật khẩu có độ dài từ 6-20 ký tự", MinimumLength = 5)]
       
        [Compare("Password",ErrorMessage ="Mật khẩu bạn nhập lại không khớp")]
        public string RePassword { get; set; }


        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa điền địa chỉ !")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa điền số điện thoại !")]
       
        public string Phone { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Bạn chưa điền địa chỉ email !")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Email không dúng định dạng.!")]
        public string Email { get; set; }



        [Display(Name = "Quyền của tài khoản (Tích chọn thì có thể đăng nhập vào trang quản trị)")]
        public bool Permission { get; set; }

        [Display(Name = "Trạng thái tài khoản (Tích chọn thì tài khoản có thể bắt đầu đăng nhập được trên hệ thống)")]
        public bool Status { get; set; }

    }
}