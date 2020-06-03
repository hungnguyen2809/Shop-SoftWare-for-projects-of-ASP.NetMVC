namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        public string IDProduct { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage ="Bạn chưa điền tên sảm phẩm")]
        [Display(Name ="Tên sản phẩm")]
        public string NameProduct { get; set; }

        [StringLength(50)]      
        [Required(ErrorMessage = "Bạn chưa chọn danh mục cho sảm phẩm")]
        [Display(Name = "Danh mục sản phẩm")]
        public string IDCategory { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa điền giá cho sảm phẩm")]
        public decimal? Price { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn của hình ảnh")]
        [Required(ErrorMessage = "Bạn chưa điền link ảnn cho sản phẩm")]
        public string Images { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng bán")]
        public int? Quantity { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifiDate { get; set; }

        [Display(Name = "Nếu tích chọn thì sản phẩm sẽ được bán và hiện thông tin sản phẩm trên trang website chính")]
        public bool Status { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
