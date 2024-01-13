using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ProductPrincipalMapping")]
public partial class SnProductPrincipalMapping
{
    [Key]
    public int ProdPrincipalMapId { get; set; }

    public int? ProductId { get; set; }

    [Column("PrincipalID")]
    public int? PrincipalId { get; set; }

    public bool? IsDeleted { get; set; }
}
