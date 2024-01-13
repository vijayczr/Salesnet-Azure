using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_Competitors")]
public partial class SnCompetitor
{
    [Key]
    public int CompetitorId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CompetitorName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CompetitorRemark { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? CompetitorStatus { get; set; }
}
