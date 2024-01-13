using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_IncentiveType")]
public partial class SnIncentiveType
{
    [Key]
    public int IncentiveTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string IncentiveType { get; set; } = null!;
}
