using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("OrderVertical")]
public partial class OrderVertical
{
    public double? F1 { get; set; }

    [Column("Ord No#")]
    public double? OrdNo { get; set; }

    [Column("Delivery On", TypeName = "datetime")]
    public DateTime? DeliveryOn { get; set; }

    [StringLength(255)]
    public string? Customer { get; set; }

    [StringLength(255)]
    public string? Contact { get; set; }

    [StringLength(255)]
    public string? Products { get; set; }

    [StringLength(255)]
    public string? Employee { get; set; }

    [StringLength(255)]
    public string? Branch { get; set; }

    [StringLength(255)]
    public string? Vertical { get; set; }

    [StringLength(255)]
    public string? Status { get; set; }

    [Column("Order Net Value")]
    public double? OrderNetValue { get; set; }

    [Column("Order Vertical")]
    [StringLength(255)]
    public string? OrderVertical1 { get; set; }
}
