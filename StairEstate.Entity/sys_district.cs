namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_district
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_district()
        {
            sys_thana = new HashSet<sys_thana>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int District_id { get; set; }

        [StringLength(50)]
        public string District_Name { get; set; }

        public int? District_Country_id { get; set; }

        public virtual sys_country sys_country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_thana> sys_thana { get; set; }
    }
}
