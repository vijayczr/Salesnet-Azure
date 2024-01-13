using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_MonthMaster")]
public partial class SnMonthMaster
{
    [Key]
    public int MonthId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MonthName { get; set; }
}
