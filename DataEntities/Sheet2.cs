using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sheet2$")]
public partial class Sheet2
{
    [Column("Sr# No#")]
    public double? SrNo { get; set; }

    [Column("Emp ID")]
    public double? EmpId { get; set; }

    [Column("DAR ID")]
    public double? DarId { get; set; }

    [Column("Emp Name")]
    [StringLength(255)]
    public string? EmpName { get; set; }

    [Column("Lead ID")]
    public double? LeadId { get; set; }

    [Column("Created Date", TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(255)]
    public string? MovedTo { get; set; }

    [Column("HeadID")]
    public int? HeadId { get; set; }
}
