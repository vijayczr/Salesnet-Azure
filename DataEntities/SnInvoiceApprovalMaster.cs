using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_InvoiceApprovalMaster")]
public partial class SnInvoiceApprovalMaster
{
    [Key]
    public int InvoiceApprovalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InvoiceApprovalStatus { get; set; }
}
