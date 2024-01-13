using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DesignationMaster")]
public partial class SnDesignationMaster
{
    [Key]
    public int DesignationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? ParentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TeamType { get; set; }

    public bool? IsActive { get; set; }
}
