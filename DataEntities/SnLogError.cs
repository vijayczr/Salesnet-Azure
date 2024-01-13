using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_LogError")]
public partial class SnLogError
{
    [Column("LogID")]
    public int LogId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ErrorDescription { get; set; }

    [Column("UserID")]
    public int? UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Event { get; set; }

    [Column("XML")]
    [Unicode(false)]
    public string? Xml { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ErrorDate { get; set; }
}
