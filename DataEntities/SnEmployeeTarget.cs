using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeTargets")]
public partial class SnEmployeeTarget
{
    [Key]
    public int TargetId { get; set; }

    public int EmpId { get; set; }

    public double? Quater1 { get; set; }

    public double? Quater2 { get; set; }

    public double? Quater3 { get; set; }

    public double? Quater4 { get; set; }

    public int? TargetYear { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column("Quater1ASG")]
    public double? Quater1Asg { get; set; }

    [Column("Quater2ASG")]
    public double? Quater2Asg { get; set; }

    [Column("Quater3ASG")]
    public double? Quater3Asg { get; set; }

    [Column("Quater4ASG")]
    public double? Quater4Asg { get; set; }
}
