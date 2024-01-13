using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PaymentModeMaster")]
public partial class SnPaymentModeMaster
{
    [Key]
    public int PaymentModeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMode { get; set; }
}
