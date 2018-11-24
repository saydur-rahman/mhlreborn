namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prod_brand()
        {
            prod_catagory = new HashSet<prod_catagory>();
        }

        [Key]
        public int Brand_id { get; set; }

        [StringLength(50)]
        public string Brand_name { get; set; }

        public int? Company_id { get; set; }

        public virtual prod_company prod_company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prod_catagory> prod_catagory { get; set; }
    }
}
