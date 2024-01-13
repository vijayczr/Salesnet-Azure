using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OfficeDAR")]
[Index("EmployeeId", "VisitDate", Name = "_dta_index_SN_OfficeDAR_49_1701581100__K3_K4")]
public partial class SnOfficeDar
{
    [Key]
    public int InOfficeId { get; set; }

    public int? OfficeActivityId { get; set; }

    public int? EmployeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remark { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsApplication { get; set; }

    [Column("DarID")]
    public int? DarId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CollegeName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TenderNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastDateOfTender { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProductQuotedWithThePrices { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? TendorDocumentPath { get; set; }

    public int? WeeklyPlanId { get; set; }
}
