using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("sn_weeklyActivity_Bkup_02Feb2016")]
public partial class SnWeeklyActivityBkup02feb2016
{
    public int WeeklyActivityId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActivityDate { get; set; }

    public int? EmpId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Activity { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Reason { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    public int? Status { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ActivityNo { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AdvanceRequired { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AdvanceApprove { get; set; }
}
