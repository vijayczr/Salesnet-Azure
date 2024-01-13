using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_Employees_25Nov2019")]
public partial class SnEmployees25nov2019
{
    public int EmployeeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    public int? ReportingHeadId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FatherName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MotherName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? JoiningDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOfBirth { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public bool? IsMarried { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AnniversaryDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PanNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    public int? SubGroupId { get; set; }

    public int? VerticalId { get; set; }

    public int? SubVerticalId { get; set; }

    public bool? EmpStatus { get; set; }

    public int? DesignationId { get; set; }

    public int? DepartmentId { get; set; }

    [Column("CTC")]
    public double? Ctc { get; set; }

    public double? IncentiveInPercent { get; set; }

    public double? IncentiveAmount { get; set; }

    public int? ReferredById { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? VerificationDetails { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsSalesNetUser { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? HeadOffice { get; set; }

    public int? HeadOfficeId { get; set; }

    public int? RegionId { get; set; }

    public int? BranchId { get; set; }

    public int? HierarchyId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPassword { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TeamBelongsTo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Unicode(false)]
    public string? UserImage { get; set; }

    public int? GradeId { get; set; }

    [StringLength(20)]
    public string? BloodGroup { get; set; }

    [StringLength(20)]
    public string? Emergencycontactnumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Relationwiththatnumbergiven { get; set; }

    [Column(TypeName = "date")]
    public DateTime? CertificateDateOfBirth { get; set; }

    [Column("EnteredEmployeeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EnteredEmployeeId { get; set; }

    [Column("UANNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Uanno { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PhysicalLocation { get; set; }

    public double? TotalPackage { get; set; }

    public int? EmployeeStatus { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EmpStatusFromDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EmpStatusToDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PerEmail { get; set; }

    [StringLength(50)]
    public string? AadharNumber { get; set; }

    [StringLength(50)]
    public string? PersonalContactNo { get; set; }

    [StringLength(50)]
    public string? LandlineNumber { get; set; }

    [StringLength(10)]
    public string? StdNumber { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TotalNoEx { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [StringLength(50)]
    public string? PersonalEmailId { get; set; }

    [Column("TotalCTC")]
    [StringLength(50)]
    public string? TotalCtc { get; set; }
}
