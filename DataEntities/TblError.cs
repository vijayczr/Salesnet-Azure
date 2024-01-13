using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("tblError")]
public partial class TblError
{
    [StringLength(50)]
    [Unicode(false)]
    public string? LineNumber { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Error { get; set; }
}
