using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("LocalConveyanceMaster")]
public partial class LocalConveyanceMaster
{
    [Key]
    public long LocalConveyanceId { get; set; }

    public int? EmpId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PeriodFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PeriodTo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Station { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WeekStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WeekEndDate { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
