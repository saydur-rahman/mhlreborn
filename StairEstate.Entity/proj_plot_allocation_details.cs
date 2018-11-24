namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_plot_allocation_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_plot_allocation_details()
        {
            prod_current_stock_details = new HashSet<prod_current_stock_details>();
        }

        public int Id { get; set; }

        public int? Master_Id { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        public int? Saleable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_details> prod_current_stock_details { get; set; }

        public virtual proj_plot_allocation_master proj_plot_allocation_master { get; set; }
    }
}
