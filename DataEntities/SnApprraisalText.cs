using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("Sn_ApprraisalText")]
public partial class SnApprraisalText
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Unicode(false)]
    public string? Para1 { get; set; }

    [Unicode(false)]
    public string? Para2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AssesmentYear { get; set; }

    [Column("GroupID")]
    public int? GroupId { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
