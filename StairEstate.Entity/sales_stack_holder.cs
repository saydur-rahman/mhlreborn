namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_stack_holder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sales_stack_holder()
        {
            prop_Land_LandOwner = new HashSet<prop_Land_LandOwner>();
            prop_Land_Media = new HashSet<prop_Land_Media>();
        }

        [Key]
        public int stack_holder_id { get; set; }

        [StringLength(50)]
        public string stack_holder_name { get; set; }

        [StringLength(15)]
        public string stack_holder_phone { get; set; }

        [StringLength(50)]
        public string stack_holder_email { get; set; }

        [StringLength(50)]
        public string stack_holder_Father_name { get; set; }

        [StringLength(50)]
        public string stack_holder_mother_name { get; set; }

        [StringLength(50)]
        public string stack_holder_contact_person { get; set; }

        [StringLength(50)]
        public string stack_holder_contact_person_number { get; set; }

        [StringLength(200)]
        public string stack_holder_pre_address { get; set; }

        [StringLength(50)]
        public string stack_holder_per_address { get; set; }

        [StringLength(50)]
        public string stack_holder_nid_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? stack_holder_Dob { get; set; }

        [StringLength(200)]
        public string stack_holder_image { get; set; }

        public int? stack_holder_country_id { get; set; }

        public int? stack_holder_type_id { get; set; }

        public bool? deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land_LandOwner> prop_Land_LandOwner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prop_Land_Media> prop_Land_Media { get; set; }

        public virtual sales_stack_holder_type sales_stack_holder_type { get; set; }

        public virtual sys_country sys_country { get; set; }
    }
}
