using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeResignation")]
public partial class SnEmployeeResignation
{
    [Key]
    public int EmpResignationId { get; set; }

    public int? EmpId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ResignationDate { get; set; }

    public int? AcceptedBy { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ResignationReason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastWorkingDate { get; set; }
}
