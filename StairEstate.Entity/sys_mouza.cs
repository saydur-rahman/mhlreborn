namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_mouza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_mouza()
        {
            prop_Land = new HashSet<prop_Land>();
        }

        [Key]
        public int Mouza_id { get; set; }

        [StringLength(50)]
        public string Mouza_name { get; set; }

        public int? Mouza_Thana_id { get; set; }

        public bool? deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land> prop_Land { get; set; }

        public virtual sys_thana sys_thana { get; set; }
    }
}
