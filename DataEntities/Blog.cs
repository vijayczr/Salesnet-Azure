using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class Blog
{
    [Key]
    public int BlogId { get; set; }

    [StringLength(5000)]
    [Unicode(false)]
    public string? BlogTitle { get; set; }

    [Unicode(false)]
    public string? BlogBody { get; set; }

    public int? ParentId { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? BlogStatus { get; set; }

    public bool? IsActive { get; set; }
}
