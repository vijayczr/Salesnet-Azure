using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DarCommentsRead")]
public partial class SnDarCommentsRead
{
    [Key]
    public int DarCommentReadId { get; set; }

    public int? DarCommentId { get; set; }

    public int? DarUserId { get; set; }
}
