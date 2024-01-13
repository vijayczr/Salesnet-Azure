using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_GradeMaster")]
public partial class SnGradeMaster
{
    [Key]
    public int GradeId { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? Grade { get; set; }

    public bool? IsActive { get; set; }
}
