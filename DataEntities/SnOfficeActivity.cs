using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OfficeActivities")]
public partial class SnOfficeActivity
{
    [Key]
    public int OfficeActivityId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OfficeActivity { get; set; }

    public bool? IsDeleted { get; set; }
}
