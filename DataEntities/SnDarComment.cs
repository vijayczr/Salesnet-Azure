using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DarComments")]
public partial class SnDarComment
{
    [Key]
    public int DarCommentId { get; set; }

    public int? DarId { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? DarCommentText { get; set; }

    public int? DarCommentById { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DarCommentOn { get; set; }

    public bool? IsDeleted { get; set; }
}
