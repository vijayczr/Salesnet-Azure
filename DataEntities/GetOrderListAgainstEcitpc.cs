using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class GetOrderListAgainstEcitpc
{
    public int OrderId { get; set; }

    public int? DarId { get; set; }

    public int? AppEngId { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? DeliveryDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    public int? EmpId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string EventType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TrainingAndInstallationDate { get; set; }

    [Column("reportingHeadEmailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadEmailId { get; set; }

    [Column("ISREmailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? IsremailId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextDueDate { get; set; }
}
