namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prop_Land_LandOwner
    {
        public int id { get; set; }

        public int? Land_Owner { get; set; }

        public int? Land_Id { get; set; }

        public virtual prop_Land prop_Land { get; set; }

        public virtual sales_stack_holder sales_stack_holder { get; set; }
    }
}
