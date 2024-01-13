using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_employeeTargetMasterBackUp18092013")]
public partial class SnEmployeeTargetMasterBackUp18092013
{
    public int EmployeeTargetId { get; set; }

    public int? EmployeeId { get; set; }

    public double? TargetAmountQ1 { get; set; }

    public double? TargetAmountQ2 { get; set; }

    public double? TargetAmountQ3 { get; set; }

    public double? TargetAmountQ4 { get; set; }

    public double? AdditionalTrgtAmtQ1 { get; set; }

    public double? AdditionalTrgtAmtQ2 { get; set; }

    public double? AdditionalTrgtAmtQ3 { get; set; }

    public double? AdditionalTrgtAmtQ4 { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
