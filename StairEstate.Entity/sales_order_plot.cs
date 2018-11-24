namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_order_plot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sales_order_plot()
        {
            sales_order_plot_details = new HashSet<sales_order_plot_details>();
        }

        public int Id { get; set; }

        public int? SoldBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public DateTime? Time { get; set; }

        public bool? Verified { get; set; }

        public int? VerifiedBy { get; set; }

        public int? BuyerId { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        public double? TotalAmount { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [StringLength(50)]
        public string SalesOrderNO { get; set; }

        public bool? QuotationYN { get; set; }

        public int? QuotationNo { get; set; }

        public bool? FullCollected { get; set; }

        public bool? Completed { get; set; }

        public int? PaymentMode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PromiseDate { get; set; }

        public bool? SODone { get; set; }

        public int? SalesType { get; set; }

        public DateTime? ApprovalTime { get; set; }

        public double? TotalTax { get; set; }

        [StringLength(50)]
        public string ApprovalNot { get; set; }

        public int? DiscoutnAP { get; set; }

        public double? Discount { get; set; }

        public double? TotalDiscount { get; set; }

        public bool? DeliveryPending { get; set; }

        [StringLength(50)]
        public string DeliverNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProposedDeliveryDate { get; set; }

        [StringLength(50)]
        public string DeliveryFromLocation { get; set; }

        public double? PreviousDues { get; set; }

        public int? SalesPersonId { get; set; }

        public int? CompanyId { get; set; }

        public int? CountryId { get; set; }

        public int? LocationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfEntry { get; set; }

        [StringLength(50)]
        public string VoucherNo { get; set; }

        [StringLength(50)]
        public string ChallanNo { get; set; }

        public int? ProjectId { get; set; }

        [StringLength(50)]
        public string FileNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HandOverDate { get; set; }

        [StringLength(50)]
        public string HandOverVoucherNo { get; set; }

        public bool? PrimaryApproval { get; set; }

        public int? PrimaryApprovedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PrimaryApprovalDate { get; set; }

        public int? TermsAndConditionId { get; set; }

        public virtual hr_employee hr_employee { get; set; }

        public virtual proj_project proj_project { get; set; }

        public virtual sales_customer sales_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order_plot_details> sales_order_plot_details { get; set; }

        public virtual sys_country sys_country { get; set; }

        public virtual sales_sales_order_customer sales_sales_order_customer { get; set; }
    }
}
