namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DescriptionTwo")]
    public partial class DescriptionTwo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string IDCategory { get; set; }

        [Key]
        [Column(Order = 1)]
        public long IDDesTwo { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool? Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
