using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_ApprraisalMasterSalaryBreakup_18Apr2019")]
public partial class SnApprraisalMasterSalaryBreakup18apr2019
{
    [Column("BreakUpID")]
    public int BreakUpId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BreakUpName { get; set; }

    public bool? IsYearly { get; set; }

    public bool? IsEarnings { get; set; }

    public int? DisplayOrder { get; set; }

    [Column("ShowToUI")]
    public bool? ShowToUi { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
