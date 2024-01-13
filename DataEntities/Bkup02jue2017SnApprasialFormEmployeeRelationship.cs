using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Bkup_02Jue2017_SN_ApprasialFormEmployeeRelationship")]
public partial class Bkup02jue2017SnApprasialFormEmployeeRelationship
{
    [Column("FormEmployeeID")]
    public int FormEmployeeId { get; set; }

    public int FormId { get; set; }

    public int EmployeeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DesRecManager { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? ManagerHikeRec { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ManagerAmountRec { get; set; }

    [Column("COODesRec")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CoodesRec { get; set; }

    [Column("COOHikeRec", TypeName = "decimal(5, 2)")]
    public decimal? CoohikeRec { get; set; }

    [Column("COOAmountRec", TypeName = "decimal(18, 2)")]
    public decimal? CooamountRec { get; set; }

    [Column("CEODesRec")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CeodesRec { get; set; }

    [Column("CEOHikeRec", TypeName = "decimal(5, 2)")]
    public decimal? CeohikeRec { get; set; }

    [Column("CEOAmountRec", TypeName = "decimal(18, 2)")]
    public decimal? CeoamountRec { get; set; }

    [Column("HRComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hrcomment { get; set; }

    public int? StatusId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmpSubmissionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ManagerSubmissionDate { get; set; }

    [Column("CEOSubmissionDate", TypeName = "datetime")]
    public DateTime? CeosubmissionDate { get; set; }

    [Column("COOSubmissionDate", TypeName = "datetime")]
    public DateTime? CoosubmissionDate { get; set; }

    [Column("HRSubmissionDate", TypeName = "datetime")]
    public DateTime? HrsubmissionDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ManagerComment { get; set; }

    [Column("COOComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Coocomment { get; set; }

    [Column("CEOComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Ceocomment { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question1 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question2 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question3 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question4 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question5 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question6 { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? Question7 { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Appraisalletters { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Promotionletters { get; set; }

    [Column("HierarchyRecommendedByCEO")]
    public int? HierarchyRecommendedByCeo { get; set; }

    public int? Rehike { get; set; }

    [Column(TypeName = "date")]
    public DateTime? WithEffectFrom { get; set; }
}
