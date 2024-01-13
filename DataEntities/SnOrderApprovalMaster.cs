using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderApprovalMaster")]
public partial class SnOrderApprovalMaster
{
    [Key]
    public int OrderApprovalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OrderApprovalStatus { get; set; }
}
