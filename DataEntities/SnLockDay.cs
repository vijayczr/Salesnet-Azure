using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_LockDays")]
public partial class SnLockDay
{
    [Column("LockID")]
    public short LockId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LockDays { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Comments { get; set; }

    public bool? IsActive { get; set; }
}
