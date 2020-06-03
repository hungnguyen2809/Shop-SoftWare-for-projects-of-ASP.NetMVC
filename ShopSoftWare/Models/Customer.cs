using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopSoftWare.Models
{
    [Serializable]
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(250)]
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn chưa điền họ tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn chưa điền địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bạn chưa điền số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn chưa điền email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}