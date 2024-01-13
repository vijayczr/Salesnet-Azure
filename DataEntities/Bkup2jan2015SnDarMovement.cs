using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("BKUP_2Jan2015_SN_DarMovement")]
public partial class Bkup2jan2015SnDarMovement
{
    public int DarMovementId { get; set; }

    public int? DarId { get; set; }

    public int? LeadId { get; set; }

    public int? CustId { get; set; }

    public int? ContactPersonId { get; set; }

    public int? MoveFrom { get; set; }

    public int? MoveTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    public bool? MovementStatus { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? EmpId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Action { get; set; }

    [Unicode(false)]
    public string? Comments { get; set; }
}
