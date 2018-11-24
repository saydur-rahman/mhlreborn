namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proj_project_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proj_project_type()
        {
            proj_project = new HashSet<proj_project>();
        }

        [Key]
        public int project_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string project_type { get; set; }

        public int? catagory_id { get; set; }

        public virtual prod_catagory prod_catagory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proj_project> proj_project { get; set; }
    }
}
