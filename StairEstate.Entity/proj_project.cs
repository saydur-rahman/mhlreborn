namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_project()
        {
            prod_current_stock_master = new HashSet<prod_current_stock_master>();
            proj_plot_allocation_master = new HashSet<proj_plot_allocation_master>();
            prop_Land_Contribution = new HashSet<prop_Land_Contribution>();
            sales_order_plot = new HashSet<sales_order_plot>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string project_id { get; set; }

        [Required]
        [StringLength(50)]
        public string project_initial { get; set; }

        public int? project_type_id { get; set; }

        [Required]
        [StringLength(100)]
        public string project_name { get; set; }

        [Required]
        [StringLength(200)]
        public string project_address { get; set; }

        public int project_status { get; set; }

        [Column(TypeName = "date")]
        public DateTime project_start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime project_end_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? project_actual_handover_date { get; set; }

        [Required]
        [StringLength(20)]
        public string project_serial { get; set; }

        public int? project_manager_id { get; set; }

        public int? project_branch_id { get; set; }

        [StringLength(200)]
        public string project_image { get; set; }

        public bool? deleted { get; set; }

        public virtual hr_employee hr_employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_master> prod_current_stock_master { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_plot_allocation_master> proj_plot_allocation_master { get; set; }

        public virtual proj_project_status proj_project_status { get; set; }

        public virtual proj_project_type proj_project_type { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land_Contribution> prop_Land_Contribution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order_plot> sales_order_plot { get; set; }
    }
}
