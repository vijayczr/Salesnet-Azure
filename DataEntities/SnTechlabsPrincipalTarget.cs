using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_TechlabsPrincipalTarget")]
public partial class SnTechlabsPrincipalTarget
{
    [Key]
    public int TechPrincipalId { get; set; }

    public int? PrincipalId { get; set; }

    public int? Qid { get; set; }

    public double? TargetAmount { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
