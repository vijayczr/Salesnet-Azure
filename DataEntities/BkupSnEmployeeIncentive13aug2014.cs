using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("BKUP_SN_EmployeeIncentive_13Aug2014")]
public partial class BkupSnEmployeeIncentive13aug2014
{
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
