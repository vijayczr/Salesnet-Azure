using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[PrimaryKey("DarId", "ProductId")]
[Table("SN_DarProducts")]
public partial class SnDarProduct
{
    public int DarProductId { get; set; }

    [Key]
    public int DarId { get; set; }

    [Key]
    public int ProductId { get; set; }

    public bool? IsDeleted { get; set; }

    public double? DarProductPrice { get; set; }

    public double? QuotedPrice { get; set; }

    public double? ProductValue { get; set; }
}
