using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_AppraisalQuestionSetMaster")]
public partial class SnAppraisalQuestionSetMaster
{
    [Key]
    public int QuestionSetId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? QuestionSet { get; set; }

    public bool? IsDeleted { get; set; }
}
