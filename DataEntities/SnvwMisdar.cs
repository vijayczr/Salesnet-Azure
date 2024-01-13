using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SnvwMisdar
{
    public int DarId { get; set; }

    public int? LeadId { get; set; }

    public double? ActualValue { get; set; }

    public double? TotalOrderValue { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CallType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Callstatus { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SubVerticalName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactPerson { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DarStatus { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(58)]
    [Unicode(false)]
    public string? ActivityArea { get; set; }

    public double? ActivityAreaPercentage { get; set; }

    public double? Tot { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? FunnelTot { get; set; }

    [Column("totPer")]
    [StringLength(11)]
    [Unicode(false)]
    public string? TotPer { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? HeadOfficeName { get; set; }

    [Unicode(false)]
    public string? Products { get; set; }

    public int? EmpId { get; set; }

    public int? CustId { get; set; }

    public int? ContactPersonId { get; set; }

    public int? CallTypeId { get; set; }

    public int? CallStatusId { get; set; }

    public int? CallSemesterId { get; set; }

    public int? DarStageId { get; set; }

    public int? DarStatusId { get; set; }

    public double? Price { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DocumentPath { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DarRemark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VisitTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DarClosingDate { get; set; }

    public int? LostReasonId { get; set; }

    public int? HeadOfficeId { get; set; }

    public int? RegionId { get; set; }

    public int? BranchId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeadType { get; set; }

    public int? LeadTypeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? LostReason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextActionDate { get; set; }

    public int? VerticalId { get; set; }

    public int? SubVerticalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MonthOfOrder { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactPhone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactMobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactEmail { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? ReportingHeadId { get; set; }

    [Column("totPerValue")]
    public double? TotPerValue { get; set; }

    [Column("IsAppDAR")]
    public bool? IsAppDar { get; set; }

    [Column("DARVerticalId")]
    public int? DarverticalId { get; set; }

    [Column("OldDarID")]
    public long? OldDarId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? CustomerAddress1 { get; set; }

    public double? TaxOption { get; set; }

    public int? HierarchyId { get; set; }
}
