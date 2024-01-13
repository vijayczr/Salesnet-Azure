using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ApprasialFormStaticQuestionRelationship")]
public partial class SnApprasialFormStaticQuestionRelationship
{
    [Key]
    [Column("StaticTransID")]
    public int StaticTransId { get; set; }

    [Column("FormID")]
    public int? FormId { get; set; }

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
