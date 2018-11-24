namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_plot_sales_details
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [StringLength(50)]
        public string ProductId { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        public int? UnitId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? Year { get; set; }

        [StringLength(50)]
        public string Cnt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfEntry { get; set; }

        [StringLength(50)]
        public string LcNo { get; set; }

        public bool? ReturnYN { get; set; }

        public double? Discount { get; set; }

        public virtual prod_product prod_product { get; set; }

        public virtual prop_unit prop_unit { get; set; }
    }
}
