using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_ApprraisalSalaryBreakupValue")]
public partial class SnApprraisalSalaryBreakupValue
{
    [Column("BreakUpID")]
    public int? BreakUpId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Value { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AssesmentYear { get; set; }

    /// <summary>
    /// P-Percentage
    /// A-Amount
    /// </summary>
    [StringLength(1)]
    public string? PercentOrAmount { get; set; }

    public int? GroupId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
