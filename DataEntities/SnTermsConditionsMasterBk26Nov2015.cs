using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_TermsConditionsMaster_bk26Nov2015")]
public partial class SnTermsConditionsMasterBk26Nov2015
{
    public int TermsConditionId { get; set; }

    public int BranchId { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string TermsConditions { get; set; } = null!;

    public bool Active { get; set; }

    [Column(TypeName = "date")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ModifiedDate { get; set; }
}
