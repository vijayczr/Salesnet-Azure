using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SnvwLatestDarForAppEngg
{
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactPerson { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? VisitDateFormated { get; set; }

    [Unicode(false)]
    public string? Products { get; set; }

    [StringLength(1063)]
    [Unicode(false)]
    public string? DarComment { get; set; }

    public int DarId { get; set; }

    public int? EmpId { get; set; }

    public int? LeadId { get; set; }

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

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DarRemark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VisitTime { get; set; }

    public int? LeadTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextActionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DarClosingDate { get; set; }

    public int? LostReasonId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IsFundAvailable { get; set; }

    public int? FundTypeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OtherFundType { get; set; }

    public double? AdvancePay { get; set; }

    public double? DeliveryPay { get; set; }

    public double? TrainingPay { get; set; }

    [Column("VAT")]
    public double? Vat { get; set; }

    [Column("GST")]
    public double? Gst { get; set; }

    [Column("CST")]
    public double? Cst { get; set; }

    [Column("FORMC")]
    public double? Formc { get; set; }

    [Column("ST")]
    public double? St { get; set; }

    public double? TaxOption { get; set; }

    public double? TotalOrderValue { get; set; }

    public double? ActualValue { get; set; }

    public int? AppEnggId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MonthOfOrder { get; set; }

    public int? WeeklyPlanId { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    [Column("IsAppDAR")]
    public bool? IsAppDar { get; set; }

    [Column("MEngId")]
    public int? MengId { get; set; }

    public int? DarOtherId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProposalGiven { get; set; }

    public int? VerticalId { get; set; }

    [Column("OldDarID")]
    public long? OldDarId { get; set; }
}
