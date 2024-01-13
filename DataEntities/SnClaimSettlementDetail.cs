using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimSettlementDetails")]
public partial class SnClaimSettlementDetail
{
    [Key]
    [Column("ClaimSettlementID")]
    public int ClaimSettlementId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ChequeNo { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ChequeDate { get; set; }

    public double? Amount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SalaryMonth { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? BankName { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReceiverName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
