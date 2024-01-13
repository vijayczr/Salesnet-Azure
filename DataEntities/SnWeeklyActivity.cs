using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_WeeklyActivity")]
[Index("EmpId", Name = "SN_EmpID")]
public partial class SnWeeklyActivity
{
    [Key]
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

    [StringLength(20)]
    [Unicode(false)]
    public string? IsAdvanceProcessed { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AdvanceProcessDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AdvanceProcessed { get; set; }

    public int? IsCreatedByUser { get; set; }

    [Column("ApprovedByRH")]
    public int? ApprovedByRh { get; set; }

    public int? ApprovedByAcc { get; set; }

    public int? IsBillSubmitted { get; set; }

    public int? IsBillUpdatedByUser { get; set; }

    public int? IsVoucherUpdated { get; set; }

    [StringLength(20)]
    public string? FinalAmount { get; set; }

    public int? BalanceAmount { get; set; }

    public int? IsClosed { get; set; }
}
