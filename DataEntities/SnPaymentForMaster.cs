using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PaymentForMaster")]
public partial class SnPaymentForMaster
{
    [Key]
    public int PaymentForId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentFor { get; set; }
}
