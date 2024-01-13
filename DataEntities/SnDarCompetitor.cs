using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DarCompetitors")]
public partial class SnDarCompetitor
{
    [Key]
    public int DarCompId { get; set; }

    public int? DarId { get; set; }

    public int? CompetitorId { get; set; }

    public bool? IsDeleted { get; set; }
}
