using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("script")]
public partial class Script
{
    [Column("USE  TechlabSalesNetConverted ")]
    [StringLength(50)]
    public string? UseTechlabSalesNetConverted { get; set; }
}
