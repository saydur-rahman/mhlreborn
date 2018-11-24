namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prod_product()
        {
            proj_plot = new HashSet<proj_plot>();
        }

        [Key]
        public int Prod_id { get; set; }

        public int? Prod_catagory_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Prod_date { get; set; }

        public bool? Prod_active { get; set; }

        public int? Prod_type_id { get; set; }

        public bool? deleted { get; set; }

        public virtual prod_catagory prod_catagory { get; set; }

        public virtual Prod_type Prod_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_plot> proj_plot { get; set; }

        public virtual sales_order_plot_details sales_order_plot_details { get; set; }

        public virtual sales_plot_sales_details sales_plot_sales_details { get; set; }
    }
}
