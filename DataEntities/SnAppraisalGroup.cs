using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_AppraisalGroups")]
public partial class SnAppraisalGroup
{
    [Key]
    public int GroupId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
