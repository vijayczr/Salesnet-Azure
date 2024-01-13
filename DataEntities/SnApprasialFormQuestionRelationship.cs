using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ApprasialFormQuestionRelationship")]
public partial class SnApprasialFormQuestionRelationship
{
    [Key]
    public int TransId { get; set; }

    public int? FormId { get; set; }

    public int? SectionId { get; set; }

    public int? QuestionId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}
