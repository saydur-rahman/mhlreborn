namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prop_Land
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prop_Land()
        {
            prop_Land_LandOwner = new HashSet<prop_Land_LandOwner>();
            prop_Land_Media = new HashSet<prop_Land_Media>();
        }

        [Key]
        public int Land_id { get; set; }

        [StringLength(50)]
        public string Land_id_shown { get; set; }

        [StringLength(50)]
        public string Land_JL_no { get; set; }

        [StringLength(50)]
        public string Land_Khatian_no { get; set; }

        [StringLength(50)]
        public string Land_Dag_no { get; set; }

        public double? Land_Area { get; set; }

        public double? Land_Rate_Per_Dag { get; set; }

        public int? Land_Unit_id { get; set; }

        public int? Land_Mouza_id { get; set; }

        public int? Land_Con_id { get; set; }

        public bool? deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land_LandOwner> prop_Land_LandOwner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land_Media> prop_Land_Media { get; set; }

        public virtual prop_Land_Contribution prop_Land_Contribution { get; set; }

        public virtual prop_unit prop_unit { get; set; }

        public virtual sys_mouza sys_mouza { get; set; }
    }
}
