using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SnvwOrderProcessingProduct
{
    public int? DarId { get; set; }

    public int PrincipalId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PrincipalName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    public int ProductId { get; set; }
}
