using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SnvwAppmi
{
    public int InOfficeId { get; set; }

    public int? OfficeActivityId { get; set; }

    [Column("DarID")]
    public int? DarId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AppActivity { get; set; }

    public int? LeadId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

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

    public int? EmployeeId { get; set; }

    public int? CustId { get; set; }

    public int? DarStageId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    public int? HeadOfficeId { get; set; }

    public int? RegionId { get; set; }

    public int? BranchId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? DarIsDeleted { get; set; }
}
