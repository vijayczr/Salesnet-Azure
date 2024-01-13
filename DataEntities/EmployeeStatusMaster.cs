using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("EmployeeStatusMaster")]
public partial class EmployeeStatusMaster
{
    [Key]
    public int EmployeeStatusId { get; set; }

    [StringLength(100)]
    public string? EmployeeStatusName { get; set; }

    public bool? IsActive { get; set; }
}
