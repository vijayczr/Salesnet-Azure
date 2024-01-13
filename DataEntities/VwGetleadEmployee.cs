using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class VwGetleadEmployee
{
    public int LeadId { get; set; }

    public int? LeadTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LeadDate1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LeadDate { get; set; }

    public int? EmpId { get; set; }

    public int? CustId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeadOrigin { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? LeadDescription { get; set; }

    [Column("DARCount")]
    public int? Darcount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FromEmployee { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("VerticalID")]
    public int? VerticalId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ContactPerson { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string ContactEmail { get; set; } = null!;
}
