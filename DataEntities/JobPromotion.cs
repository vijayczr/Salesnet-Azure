using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class JobPromotion
{
    [Key]
    [Column("JobPromotionID")]
    public int JobPromotionId { get; set; }

    public int? UserGroup { get; set; }

    public int? UserType { get; set; }

    public int? Department { get; set; }

    public int? Location { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? JobTitle { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? JobTag { get; set; }

    [Unicode(false)]
    public string? JobDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? JobLastSubmissionDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
