using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_RevenuePercentage")]
public partial class SnRevenuePercentage
{
    [Key]
    [Column("RevenuePercentageID")]
    public int RevenuePercentageId { get; set; }

    [Column("VerticalID")]
    public int? VerticalId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ProductPercentage { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ProjectPercentage { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// 1- Active
    /// 0 - De-Active
    /// </summary>
    public bool? IsActive { get; set; }
}
