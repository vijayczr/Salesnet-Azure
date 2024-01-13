using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_AppraisalStaticQuestions")]
public partial class SnAppraisalStaticQuestion
{
    [Key]
    public int StaticQuestionId { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? StaticQuestion { get; set; }

    public int? QuestionSet { get; set; }

    public int? QuestionPriority { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }
}
