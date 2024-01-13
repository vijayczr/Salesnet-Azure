using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LeadStatus")]
public partial class SnLeadStatus
{
    [Key]
    public int LeadStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeadStatus { get; set; }

    public bool? IsDeleted { get; set; }
}
