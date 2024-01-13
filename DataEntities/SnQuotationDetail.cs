using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_QuotationDetail")]
public partial class SnQuotationDetail
{
    [Key]
    public int QuotationId { get; set; }

    [Column("DARId")]
    public int Darid { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string QuotationRefNo { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string ContactPersonName { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? KindAttention { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? QuotationSubject { get; set; }

    public bool? IsTendar { get; set; }

    [Column("EMDAmount")]
    public double? Emdamount { get; set; }

    [Column("EMDPaymentMode")]
    public int? EmdpaymentMode { get; set; }

    [Column("EMDBankName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmdbankName { get; set; }

    [Column("EMDCheqDDDate", TypeName = "datetime")]
    public DateTime? EmdcheqDddate { get; set; }

    [Column("EMDCheqDDNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmdcheqDdno { get; set; }

    [Column("EMDBankTransactionDate", TypeName = "datetime")]
    public DateTime? EmdbankTransactionDate { get; set; }

    [Column("EMDBankTransactionId")]
    [StringLength(20)]
    [Unicode(false)]
    public string? EmdbankTransactionId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TendarNo { get; set; }

    public int ReferencedQuotationNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ModificationNo { get; set; }

    [Column("TCId")]
    public int Tcid { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Note { get; set; }

    public int StaticTextId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TenderDate { get; set; }

    public bool? QuotationStatus { get; set; }

    public bool? IsLatest { get; set; }

    public int? CreatedBy { get; set; }

    [Column("CollectEMDDetail")]
    public bool? CollectEmddetail { get; set; }

    public int? ModifiedBy { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Salutation { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Valedictions { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? StaticText1 { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? StaticText2 { get; set; }

    public int? VerticalId { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? QuotationPdfName { get; set; }
}
