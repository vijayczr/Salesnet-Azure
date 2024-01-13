using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ApprasialAudit")]
public partial class SnApprasialAudit
{
    [Key]
    [Column("AuditID")]
    public long AuditId { get; set; }

    [Column("FormEmployeeID")]
    public int? FormEmployeeId { get; set; }

    [Column("CEODesRec")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CeodesRec { get; set; }

    [Column("CEOHikeRec", TypeName = "decimal(5, 2)")]
    public decimal? CeohikeRec { get; set; }

    [Column("CEOAmountRec", TypeName = "decimal(18, 2)")]
    public decimal? CeoamountRec { get; set; }

    [Column("CEOSubmissionDate", TypeName = "datetime")]
    public DateTime? CeosubmissionDate { get; set; }

    [Column("CEOComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Ceocomment { get; set; }

    public int? StatusId { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column("HierarchyRecommendedByCEO")]
    public int? HierarchyRecommendedByCeo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }
}
