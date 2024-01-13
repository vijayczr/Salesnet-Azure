using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DarOther")]
public partial class SnDarOther
{
    [Key]
    public int DarOtherId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DarOther { get; set; }
}
