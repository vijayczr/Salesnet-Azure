using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeIncentiverenamed")]
public partial class SnEmployeeIncentiverenamed
{
    [Key]
    public int IncentiveId { get; set; }

    public int? EmployeeTargetId { get; set; }

    public int? Qid { get; set; }

    public double? TargetAmount { get; set; }

    public double? TargetIncentive { get; set; }

    public double? EarnedIncentive { get; set; }

    public double? Discount { get; set; }

    public double? CalculatedIncentive { get; set; }

    public double? Achievement { get; set; }

    public double? CreditedIncentive { get; set; }

    public bool? AppIncentiveType { get; set; }

    public int? VerticalId { get; set; }

    public double? CreditDiscount { get; set; }
}
