namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_sales_order_customer
    {
        public int Id { get; set; }

        public int? SalesOrderId { get; set; }

        public int? BuyerId { get; set; }

        public bool? Principal { get; set; }

        [StringLength(50)]
        public string RelationWithPrincipal { get; set; }

        public bool? BuyerRole { get; set; }

        public virtual sales_customer sales_customer { get; set; }

        public virtual sales_order_plot sales_order_plot { get; set; }
    }
}
