using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("BillTransaction")]
public partial class BillTransaction
{
    public long? BillTransactionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? From { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? To { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Mode { get; set; }

    public int? CustId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Amount { get; set; }

    /// <summary>
    /// L-Local
    /// T-Tour
    /// </summary>
    [StringLength(5)]
    [Unicode(false)]
    public string? Type { get; set; }

    [StringLength(50)]
    public string? VoucherNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    public int? EmpId { get; set; }
}
