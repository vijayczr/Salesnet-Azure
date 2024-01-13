using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CustomerProducts")]
[Index("CustProductId", "ProductId", "CustomerId", Name = "ix_SN_CustomerProducts")]
public partial class SnCustomerProduct
{
    [Key]
    public int CustProductId { get; set; }

    public int? ProductId { get; set; }

    public bool? CustProductStatus { get; set; }

    public double? Total { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remark { get; set; }

    public bool? CustProStatus { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CustomerId { get; set; }
}
