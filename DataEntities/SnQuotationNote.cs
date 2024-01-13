using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_QuotationNote")]
public partial class SnQuotationNote
{
    [Key]
    public int AutoId { get; set; }

    [Column(TypeName = "text")]
    public string? Text { get; set; }

    public bool? Active { get; set; }
}
