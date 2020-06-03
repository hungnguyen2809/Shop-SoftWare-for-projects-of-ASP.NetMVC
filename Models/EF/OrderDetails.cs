namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDOrder { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string IDProduct { get; set; }

        [StringLength(250)]
        public string NameProduct { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
