namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_plot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_plot()
        {
            proj_plot_allocation_master = new HashSet<proj_plot_allocation_master>();
        }

        [Key]
        public int Plot_id { get; set; }

        public int? Prod_id { get; set; }

        public int? Block_id { get; set; }

        public int? Road_id { get; set; }

        public int? Facing_id { get; set; }

        public double? Plot_Size { get; set; }

        public int? Unit_id { get; set; }

        [StringLength(200)]
        public string Plot_desc { get; set; }

        public bool? deleted { get; set; }

        public virtual prod_product prod_product { get; set; }

        public virtual proj_block proj_block { get; set; }

        public virtual proj_facing proj_facing { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_plot_allocation_master> proj_plot_allocation_master { get; set; }

        public virtual proj_road proj_road { get; set; }

        public virtual prop_unit prop_unit { get; set; }
    }
}
