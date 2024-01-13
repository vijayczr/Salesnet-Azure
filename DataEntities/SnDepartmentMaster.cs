using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DepartmentMaster")]
public partial class SnDepartmentMaster
{
    [Key]
    public int DeptId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DeptName { get; set; }

    public bool? IsDeleted { get; set; }
}
