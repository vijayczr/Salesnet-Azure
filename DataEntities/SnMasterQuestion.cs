using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_MasterQuestion")]
public partial class SnMasterQuestion
{
    [Key]
    public int QuestionId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? QuestionName { get; set; }

    public int? QuestionOrder { get; set; }

    public int? SectionId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}
