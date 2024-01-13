using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LeadTypeMaster")]
public partial class SnLeadTypeMaster
{
    [Key]
    public int LeadTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeadType { get; set; }

    public bool? IsDeleted { get; set; }
}
