using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ActivityAreas")]
public partial class SnActivityArea
{
    [Key]
    public int ActivityAreaId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ActivityArea { get; set; }

    public double? ActivityAreaPercentage { get; set; }

    public int? ActivityAreaOrder { get; set; }

    public bool? IsDeleted { get; set; }
}
