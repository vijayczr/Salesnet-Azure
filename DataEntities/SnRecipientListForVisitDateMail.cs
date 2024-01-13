using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_RecipientListForVIsitDateMail")]
public partial class SnRecipientListForVisitDateMail
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("DarID")]
    public long? DarId { get; set; }

    [Column("LeadID")]
    public long? LeadId { get; set; }

    [Column("DarStageID")]
    public int? DarStageId { get; set; }

    [Column("DarStatusID")]
    public int? DarStatusId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? VisitDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? EmpEmail { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? ContactPerson { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? ContactEmail { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ContactMobile { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Dept { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    public bool? DeliveryStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SendingDate { get; set; }
}
