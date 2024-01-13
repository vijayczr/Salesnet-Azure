using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class Quote
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Quote")]
    [StringLength(500)]
    [Unicode(false)]
    public string Quote1 { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Author { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DisplayOn { get; set; }

    public bool? IsDefault { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }
}
