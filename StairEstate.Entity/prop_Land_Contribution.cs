namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prop_Land_Contribution
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prop_Land_Contribution()
        {
            prop_Land = new HashSet<prop_Land>();
        }

        [Key]
        public int Land_Con_id { get; set; }

        [StringLength(50)]
        public string Land_Con_Auto_id { get; set; }

        public int? Land_Con_Project_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Land_Con_Date_Created { get; set; }

        public int? Land_Con_branch_Id { get; set; }

        public bool? deleted { get; set; }

        public virtual proj_project proj_project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land> prop_Land { get; set; }

        public virtual sys_branch sys_branch { get; set; }
    }
}
