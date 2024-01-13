using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CallStatusMaster")]
public partial class SnCallStatusMaster
{
    [Key]
    public int CallStatusMasterId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Callstatus { get; set; }

    public bool? IsDeleted { get; set; }
}
