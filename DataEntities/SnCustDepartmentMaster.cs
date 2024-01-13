using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CustDepartmentMaster")]
[Index("CustDeptId", Name = "ix_SN_CustDepartmentMaster")]
public partial class SnCustDepartmentMaster
{
    [Key]
    public int CustDeptId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustDeptName { get; set; }

    public bool? IsDeleted { get; set; }
}
