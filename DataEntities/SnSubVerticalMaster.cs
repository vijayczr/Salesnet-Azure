using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_SubVerticalMaster")]
public partial class SnSubVerticalMaster
{
    [Key]
    public int SubVerticalId { get; set; }

    public int VerticalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SubVerticalName { get; set; }

    public bool? IsDeleted { get; set; }
}
