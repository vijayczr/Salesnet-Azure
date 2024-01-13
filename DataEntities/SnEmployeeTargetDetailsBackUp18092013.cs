using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_EmployeeTargetDetailsBackUp18092013")]
public partial class SnEmployeeTargetDetailsBackUp18092013
{
    public int EmployeeTargetDetailId { get; set; }

    public int? EmployeeTargetId { get; set; }

    public int? Qid { get; set; }

    public int? VerticalId { get; set; }

    public int? PrincipalId { get; set; }

    public int? MonthId { get; set; }

    public double? TargetAmount { get; set; }

    public double? CalculatedTrgtAmt { get; set; }

    public double? AdditionalTrgtAmt { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public double? Achievement { get; set; }

    public bool? GroupTarget { get; set; }
}
