namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public long ID { get; set; }

        public long? CustomerID { get; set; }

        [StringLength(250)]
        public string OrderName { get; set; }

        [StringLength(250)]
        public string OrderAddress { get; set; }

        [StringLength(50)]
        public string OderPhone { get; set; }

        [StringLength(250)]
        public string OrderEmail { get; set; }

        [Column(TypeName = "ntext")]
        public string OrderRequest { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
