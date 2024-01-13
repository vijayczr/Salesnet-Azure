using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SnvwDarcompetitor
{
    public int DarId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CompetitorName { get; set; }

    public int CompetitorId { get; set; }
}
