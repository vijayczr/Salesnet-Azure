using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("CEOMessages")]
public partial class Ceomessage
{
    [Key]
    [Column("CEOMsgID")]
    public int CeomsgId { get; set; }

    [Column("CEOMessage")]
    [Unicode(false)]
    public string? Ceomessage1 { get; set; }

    [Column("CEOImage")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Ceoimage { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    [Column("CEOSummary")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Ceosummary { get; set; }
}
