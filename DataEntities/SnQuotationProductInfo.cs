using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_QuotationProductInfo")]
public partial class SnQuotationProductInfo
{
    [Key]
    public int QuotationProductId { get; set; }

    public int QuotationId { get; set; }

    public int ProductId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProductDesc { get; set; }

    public int Qty { get; set; }

    public double TotalPrice { get; set; }

    public int DarId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Options { get; set; } = null!;

    public bool? OptionChoosen { get; set; }
}
