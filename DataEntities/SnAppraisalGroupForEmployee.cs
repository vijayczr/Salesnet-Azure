using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_AppraisalGroupForEmployee")]
public partial class SnAppraisalGroupForEmployee
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? EmployeeId { get; set; }

    public int? BranchId { get; set; }

    public int? AppraisalCategroyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
