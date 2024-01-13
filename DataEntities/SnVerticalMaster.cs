using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_VerticalMaster")]
public partial class SnVerticalMaster
{
    [Key]
    public int VerticalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    public bool? IsDeleted { get; set; }
}
