using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("FileName1234")]
public partial class FileName1234
{
    [Column("Login Id")]
    public double? LoginId { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? Manager { get; set; }

    [StringLength(255)]
    public string? Vertical { get; set; }

    [StringLength(255)]
    public string? Designation { get; set; }

    [StringLength(255)]
    public string? Branch { get; set; }

    [StringLength(255)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? F8 { get; set; }

    [StringLength(255)]
    public string? F9 { get; set; }
}
