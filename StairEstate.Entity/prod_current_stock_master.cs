namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_current_stock_master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prod_current_stock_master()
        {
            prod_current_stock_details = new HashSet<prod_current_stock_details>();
        }

        public int Id { get; set; }

        public int? Plot_Master_id { get; set; }

        public int? Branch_Id { get; set; }

        public int? Project_Id { get; set; }

        public int? Company_Id { get; set; }

        public int? Country_Id { get; set; }

        public virtual company company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_details> prod_current_stock_details { get; set; }

        public virtual proj_plot_allocation_master proj_plot_allocation_master { get; set; }

        public virtual proj_project proj_project { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        public virtual sys_country sys_country { get; set; }
    }
}
