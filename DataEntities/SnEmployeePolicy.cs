using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeePolicies")]
public partial class SnEmployeePolicy
{
    [Key]
    public int EmpPolicyId { get; set; }

    public int? EmpId { get; set; }

    public bool? IsMediclaimPolicy { get; set; }

    [Column("MPolicyName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MpolicyName { get; set; }

    [Column("MPolicyDetail")]
    [StringLength(500)]
    [Unicode(false)]
    public string? MpolicyDetail { get; set; }

    [Column("MPolicySumAssured")]
    public double? MpolicySumAssured { get; set; }

    [Column("MPolicyExpiryDate", TypeName = "datetime")]
    public DateTime? MpolicyExpiryDate { get; set; }

    [Column("MPolicyNominee")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MpolicyNominee { get; set; }

    [Column("LPolicyName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LpolicyName { get; set; }

    [Column("LPolicyDetail")]
    [StringLength(500)]
    [Unicode(false)]
    public string? LpolicyDetail { get; set; }

    [Column("LPolicySumAssured")]
    public double? LpolicySumAssured { get; set; }

    [Column("LPolicyExpiryDate", TypeName = "datetime")]
    public DateTime? LpolicyExpiryDate { get; set; }

    [Column("LPolicyNominee")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LpolicyNominee { get; set; }
}
