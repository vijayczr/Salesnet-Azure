using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderPrincipal")]
public partial class SnOrderPrincipal
{
    [Key]
    public int OrderPrincipalId { get; set; }

    public int OrderId { get; set; }

    public int PrincipalId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LocalVendor { get; set; }

    public int? ReceivedStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReceivedDate { get; set; }

    public int? ReceivedInCondition { get; set; }

    [Column("PODate", TypeName = "datetime")]
    public DateTime? Podate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PurchasedOrderNo { get; set; }

    [Column("PONo")]
    public int? Pono { get; set; }

    [Column("PrePONo")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PrePono { get; set; }

    public int? CurrencyType { get; set; }

    [Column("TotalPOValue")]
    public double? TotalPovalue { get; set; }

    public int? TypeOfLicense { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LicenseActivatedTill { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ReceivingRemarks { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InvoiceNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceDate { get; set; }

    public double? InvoiceAmount { get; set; }

    [Column("AmountOfTannerPO")]
    public double? AmountOfTannerPo { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? InvoiceRemark { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? InvoiceDocument { get; set; }

    public int? ExtCreditPeriod { get; set; }

    public double? Freight { get; set; }

    public double? Taxes { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
