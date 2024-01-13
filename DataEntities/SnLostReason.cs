using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LostReasons")]
public partial class SnLostReason
{
    [Key]
    public int LostReasonId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? LostReason { get; set; }

    public int? LostReasonOrder { get; set; }

    public bool? IsDeleted { get; set; }
}
