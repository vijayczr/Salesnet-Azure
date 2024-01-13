using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_AppraisalStaticQuestionFormRelationship")]
public partial class SnAppraisalStaticQuestionFormRelationship
{
    [Key]
    public int TransId { get; set; }

    public int? QuestionId { get; set; }

    public int? FormEmployeeId { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? EmployeeComments { get; set; }

    [StringLength(2500)]
    [Unicode(false)]
    public string? ManagerComments { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
