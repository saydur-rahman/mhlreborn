namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prod_company()
        {
            prod_brand = new HashSet<prod_brand>();
        }

        [Key]
        public int Company_id { get; set; }

        [StringLength(50)]
        public string Company_name { get; set; }

        public int? Country_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_brand> prod_brand { get; set; }

        public virtual sys_country sys_country { get; set; }
    }
}
