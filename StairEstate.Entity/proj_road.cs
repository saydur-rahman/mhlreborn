namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_road
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_road()
        {
            proj_plot = new HashSet<proj_plot>();
        }

        [Key]
        public int Road_id { get; set; }

        [StringLength(50)]
        public string Road_no { get; set; }

        [StringLength(50)]
        public string Road_size { get; set; }

        public int? Unit_id { get; set; }

        public int? Block_id { get; set; }

        public bool? deleted { get; set; }

        public virtual proj_block proj_block { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_plot> proj_plot { get; set; }

        public virtual prop_unit prop_unit { get; set; }
    }
}
