namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class prod_current_stock_details
    {
        public int Id { get; set; }

        public int Current_Master_Id { get; set; }

        public int? Reference { get; set; }

        public int? Plot_allocation_Details_Id { get; set; }

        public bool? Sold { get; set; }

        public virtual prod_current_stock_master prod_current_stock_master { get; set; }

        public virtual proj_plot_allocation_details proj_plot_allocation_details { get; set; }
    }
}
