using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("subVerticalPrincipalMapping")]
public partial class SubVerticalPrincipalMapping
{
    [Key]
    public int Mappingid { get; set; }

    [Column("verticalid")]
    public int? Verticalid { get; set; }

    [Column("subverticalid")]
    public int? Subverticalid { get; set; }

    [Column("principalid")]
    public int? Principalid { get; set; }
}
