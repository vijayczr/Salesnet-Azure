using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_MasterAppraisalCategory")]
public partial class SnMasterAppraisalCategory
{
    public int AppraisalCategoryId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? AppraisalCategoryName { get; set; }

    public bool? IsActive { get; set; }
}
