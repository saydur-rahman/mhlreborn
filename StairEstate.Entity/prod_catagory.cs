namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_catagory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prod_catagory()
        {
            prod_product = new HashSet<prod_product>();
            proj_project_type = new HashSet<proj_project_type>();
        }

        [Key]
        public int Catagory_id { get; set; }

        [StringLength(50)]
        public string Catagory_name { get; set; }

        public int? Brand_id { get; set; }

        public virtual prod_brand prod_brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_product> prod_product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_project_type> proj_project_type { get; set; }
    }
}
