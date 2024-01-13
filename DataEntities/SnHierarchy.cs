using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_Hierarchy")]
public partial class SnHierarchy
{
    [Key]
    [Column("SNHierarchyId")]
    public int SnhierarchyId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? HierarchyName { get; set; }

    public bool? IsMarketingTeam { get; set; }

    public bool? IsApplicationTeam { get; set; }

    public bool? IsHorizontalAccess { get; set; }

    public bool? IsActive { get; set; }

    public int? ParentIdMkt { get; set; }

    public int? ParentIdApp { get; set; }
}
