namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("company")]
    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            prod_current_stock_master = new HashSet<prod_current_stock_master>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string companyname { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(100)]
        public string TIN { get; set; }

        [StringLength(50)]
        public string BIN { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string started { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_master> prod_current_stock_master { get; set; }
    }
}
