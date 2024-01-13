using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PrincipalQuarterName")]
public partial class SnPrincipalQuarterName
{
    [Key]
    public int PrincipalQid { get; set; }

    public int? PrincipalId { get; set; }

    public int? Qid { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? QuarterName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
