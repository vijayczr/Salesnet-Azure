using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_FundTypes")]
public partial class SnFundType
{
    [Key]
    public int FundTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FundType { get; set; }

    public int? FundTypeOrder { get; set; }

    public bool? IsDeleted { get; set; }

    public int? VerticalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }
}
