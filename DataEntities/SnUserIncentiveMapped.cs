using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_UserIncentiveMapped")]
public partial class SnUserIncentiveMapped
{
    [Key]
    public int UserIncentiveMappedId { get; set; }

    public int IncentiveUserId { get; set; }

    public int IncentiveTypeId { get; set; }

    public double PercentageValue { get; set; }

    [Column("employeeid")]
    public int? Employeeid { get; set; }
}
