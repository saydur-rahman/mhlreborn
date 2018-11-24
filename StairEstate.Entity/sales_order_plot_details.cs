namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_order_plot_details
    {
        public int Id { get; set; }

        public int? SalesOrderId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public int? UnitTypeId { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfEntry { get; set; }

        [StringLength(50)]
        public string Ber { get; set; }

        public double? BerAmount { get; set; }

        public double? PriceAmount { get; set; }

        public double? PriceProtectionAmount { get; set; }

        [StringLength(50)]
        public string PPM { get; set; }

        public double? PPMAmount { get; set; }

        [StringLength(50)]
        public string PPMUnit { get; set; }

        public double? SpecialPrice { get; set; }

        public int? SpecialPriceTakenBy { get; set; }

        public double? Cost { get; set; }

        public double? Discount { get; set; }

        [StringLength(50)]
        public string LcNo { get; set; }

        [StringLength(50)]
        public string SalesReturnUnit { get; set; }

        public double? SalesReturnValue { get; set; }

        public int? AppQuantity { get; set; }

        public double? Bonus { get; set; }

        public double? TradePrice { get; set; }

        public double? VatAmount { get; set; }

        [StringLength(200)]
        public string AdditionalDescription { get; set; }

        public virtual prod_product prod_product { get; set; }

        public virtual prop_unit prop_unit { get; set; }

        public virtual sales_order_plot sales_order_plot { get; set; }
    }
}
