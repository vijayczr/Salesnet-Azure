using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_AppActivities")]
public partial class SnAppActivity
{
    [Key]
    public int AppActivityId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AppActivity { get; set; }

    public int? AppActivityOrder { get; set; }

    public bool? IsDeleted { get; set; }
}
