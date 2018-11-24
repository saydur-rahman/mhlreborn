namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prop_Land_Media
    {
        public int id { get; set; }

        public int? Land_media { get; set; }

        public int? Land_id { get; set; }

        public virtual prop_Land prop_Land { get; set; }

        public virtual sales_stack_holder sales_stack_holder { get; set; }
    }
}
