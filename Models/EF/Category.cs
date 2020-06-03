namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            DescriptionOne = new HashSet<DescriptionOne>();
            DescriptionTwo = new HashSet<DescriptionTwo>();
            Product = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        public string IDCategory { get; set; }

        [StringLength(250, ErrorMessage ="Độ dài tối đa 250 ký tự")]
        [Display(Name ="Tên danh mục")]
        [Required(ErrorMessage = "Bạn chưa điền tên cho danh mục sản phẩm")]
        public string NameCategory { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        [Display(Name ="Khi bạn tích thì danh mục loại hàng này sẽ hiển thị và đồng thời nó sẽ được bán")]
        public bool Status { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DescriptionOne> DescriptionOne { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DescriptionTwo> DescriptionTwo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
