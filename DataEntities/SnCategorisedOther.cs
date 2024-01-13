using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CategorisedOthers")]
public partial class SnCategorisedOther
{
    [Key]
    public int CategorisedOtherId { get; set; }

    public int OtherId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Module { get; set; } = null!;
}
