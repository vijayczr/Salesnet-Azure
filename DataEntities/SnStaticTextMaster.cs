using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_StaticTextMaster")]
public partial class SnStaticTextMaster
{
    public int StaticTextId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string StaticTextHead { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string StaticText { get; set; } = null!;
}
