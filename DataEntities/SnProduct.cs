using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_Products")]
[Index("PrincipalId", Name = "SN_PrincipalID")]
[Index("ProductName", Name = "SN_ProductName")]
[Index("VerticalId", Name = "SN_VerticalId")]
public partial class SnProduct
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? ProductDescription { get; set; }

    public int? ProductHead { get; set; }

    public int? VerticalId { get; set; }

    public int? SubVerticalId { get; set; }

    public double? Price { get; set; }

    public double? PriceVarience { get; set; }

    public bool? ProductStatus { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public int? PrincipalId { get; set; }

    public int? Target { get; set; }
}
