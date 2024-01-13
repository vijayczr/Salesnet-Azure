using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LeadForward")]
public partial class SnLeadForward
{
    [Key]
    public int LeadForwardId { get; set; }

    public int? LeadId { get; set; }

    public int? FromEmpId { get; set; }

    public int? ToEmpId { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }
}
