using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeProductVerticals")]
public partial class SnEmployeeProductVertical
{
    [Key]
    public int EmpProductVerticalId { get; set; }

    public int? VerticalId { get; set; }

    public int? EmpId { get; set; }

    public bool? VerticalStatus { get; set; }

    public bool? IsDeleted { get; set; }
}
