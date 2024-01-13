using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PaymentDetails")]
public partial class SnPaymentDetail
{
    [Key]
    public int PaymentCollectionId { get; set; }

    public int OrderId { get; set; }

    public int? PaymentFor { get; set; }

    public int? PrincipalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentStatus { get; set; }

    public int? PaymentMode { get; set; }

    public bool? AdvancePayment { get; set; }

    public double? PaymentAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BankName { get; set; }

    [Column("CheckDDNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CheckDdno { get; set; }

    [Column("CheckDDDate", TypeName = "datetime")]
    public DateTime? CheckDddate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BankTransactionDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? BankTransactionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextDueDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PaymentRemark { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public double? AmountDue { get; set; }
}
