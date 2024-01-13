using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_MasterApprasialForm")]
public partial class SnMasterApprasialForm
{
    [Key]
    public int FormId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FormName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AssessmentYear { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AssessmentMonth { get; set; }

    public int? GroupId { get; set; }

    public bool? IsFinalForm { get; set; }

    public bool? IsPublish { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublishDate { get; set; }

    public int? PublishBy { get; set; }
}
