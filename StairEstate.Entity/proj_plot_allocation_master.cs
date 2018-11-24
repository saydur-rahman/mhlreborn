namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_plot_allocation_master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_plot_allocation_master()
        {
            prod_current_stock_master = new HashSet<prod_current_stock_master>();
            proj_plot_allocation_details = new HashSet<proj_plot_allocation_details>();
        }

        public int Id { get; set; }

        public int? Project_Id { get; set; }

        public int? Product_Id { get; set; }

        public int? Product_Unit_type_Id { get; set; }

        public int? Product_Quantity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_master> prod_current_stock_master { get; set; }

        public virtual proj_plot proj_plot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_plot_allocation_details> proj_plot_allocation_details { get; set; }

        public virtual proj_project proj_project { get; set; }

        public virtual prop_unit prop_unit { get; set; }
    }
}
