using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class Upcomingevent
{
    [Key]
    public int EventId { get; set; }

    [Unicode(false)]
    public string? EventText { get; set; }

    public bool? IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }
}
