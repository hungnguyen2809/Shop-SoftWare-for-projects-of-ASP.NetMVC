namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        [Display(Name ="Địa chỉ:")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [Display(Name = "Điện thoại:")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Ngày làm việc không được để trống")]
        [Display(Name = "Ngày làm việc trong tuần:")]
        public string DayWorkforWeek { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Thời gian làm việc không được để trống")]
        [Display(Name = "Thời gian làm việc:")]
        public string TimeWork { get; set; }

        public bool? Status { get; set; }
    }
}
