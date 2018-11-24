namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_country()
        {
            prod_current_stock_master = new HashSet<prod_current_stock_master>();
            sales_order_plot = new HashSet<sales_order_plot>();
            sales_stack_holder = new HashSet<sales_stack_holder>();
            sys_branch = new HashSet<sys_branch>();
            sys_district = new HashSet<sys_district>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? currency { get; set; }

        public virtual prod_company prod_company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_current_stock_master> prod_current_stock_master { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order_plot> sales_order_plot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_stack_holder> sales_stack_holder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_branch> sys_branch { get; set; }

        public virtual sys_currency sys_currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_district> sys_district { get; set; }
    }
}
