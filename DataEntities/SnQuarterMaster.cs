using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_QuarterMaster")]
public partial class SnQuarterMaster
{
    [Key]
    public int Qid { get; set; }

    [Column("QShortName")]
    [StringLength(10)]
    [Unicode(false)]
    public string? QshortName { get; set; }

    [Column("QStartMonthId")]
    public int? QstartMonthId { get; set; }

    [Column("QEndMonthId")]
    public int? QendMonthId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
