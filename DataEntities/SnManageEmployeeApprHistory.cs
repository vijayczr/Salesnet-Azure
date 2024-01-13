using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ManageEmployeeApprHistory")]
public partial class SnManageEmployeeApprHistory
{
    [Key]
    public int TransId { get; set; }

    public int? EmpId { get; set; }

    public int? DesgId { get; set; }

    public int? ReportingHeadId { get; set; }

    [Column("CTC")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ctc { get; set; }

    public int? GradeId { get; set; }

    public int? VerticalId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? From { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? To { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public int? Createdby { get; set; }

    public int? UpatedBy { get; set; }

    public bool? IsActive { get; set; }

    public int? SubVerticalId { get; set; }

    public int? HierarchyId { get; set; }

    public int? AppFormId { get; set; }
}
