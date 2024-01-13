using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderProducts")]
[Index("OrderPrincipalId", Name = "sn_orderderproducts_nonclustered_OrderPrincipalId")]
public partial class SnOrderProduct
{
    [Key]
    public int OrderProductId { get; set; }

    public int OrderPrincipalId { get; set; }

    public int ProductId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProductDescription { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ProductType { get; set; }

    public int? LicenseType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TermStartDate { get; set; }

    public int? Period { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LicenseActivatedFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LicenseActivatedTo { get; set; }

    public int? Warranty { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? WarrantyUnit { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PartNumber { get; set; }

    public double? QuotPrice { get; set; }

    public double? TotalProductCost { get; set; }

    public int? OrderedQuantity { get; set; }

    public int? RequiredQuantity { get; set; }

    public int? OrderReceivedQuantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderReceivedDate { get; set; }

    public int? OrderReceivedStatus { get; set; }

    public int? OrderReceivedCondition { get; set; }

    public double? AchPrice { get; set; }

    public double? TechlabCost { get; set; }
}
