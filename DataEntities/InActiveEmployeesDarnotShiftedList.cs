using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class InActiveEmployeesDarnotShiftedList
{
    [Column("reportingHeadEmailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadEmailId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    public int EmployeeId { get; set; }

    [Column("reportingTo")]
    public int? ReportingTo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadName { get; set; }

    public bool? ReportingHeadActiveStatus { get; set; }
}
