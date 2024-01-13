using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderProcessing")]
[Index("CreatedOn", "OrderId", Name = "_dta_index_SN_OrderProcessing_49_1541580530__K87_K1_2_4_6_7_8_9_10_11_19_20_21_22_23_24_26_27_28_31_33_34_35_36_37_38_49_55_66_")]
[Index("OrderDate", Name = "sn_orderderprocessing_nonclustered_OrderDate")]
public partial class SnOrderProcessing
{
    [Key]
    public int OrderId { get; set; }

    public int? DarId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? QuotationRefNo { get; set; }

    public int? AppEngId { get; set; }

    [Column("ISRId")]
    public int? Isrid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeliveryDate { get; set; }

    public double? OrderTotalValue { get; set; }

    [Column("OrderST")]
    public double? OrderSt { get; set; }

    [Column("OrderVATCST")]
    public double? OrderVatcst { get; set; }

    [Column("OrderCForm")]
    public double? OrderCform { get; set; }

    public double? OrderNetValue { get; set; }

    [Column("OrderGST")]
    public double? OrderGst { get; set; }

    [Column("OrderGSTValue")]
    public double? OrderGstvalue { get; set; }

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

    [Column("OrderAMCFrom", TypeName = "datetime")]
    public DateTime? OrderAmcfrom { get; set; }

    [Column("OrderAMCTo", TypeName = "datetime")]
    public DateTime? OrderAmcto { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderProcessingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderReConfirmingDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderProcessingRemark { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderProcessingDocument { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderProcessingDocumentSecond { get; set; }

    public int? OrderApprovalStatus { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderApprovalRemark { get; set; }

    public bool? EngineerConfirmationStatus { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? EngineerConfirmationRemark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EngineerConfirmationDate { get; set; }

    public bool? OrderPlacedStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderPlacedDate { get; set; }

    public int? CurrencyTypeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderPlacedRemark { get; set; }

    public int? OrderReceivedStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderReceivedDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderReceivedRemark { get; set; }

    public bool? InvoiceReceivedStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InvoiceReceivedDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? InvoiceRemark { get; set; }

    [Column("BGAmount")]
    public double? Bgamount { get; set; }

    [Column("BGCreateDate", TypeName = "datetime")]
    public DateTime? BgcreateDate { get; set; }

    [Column("BGPeriod")]
    public int? Bgperiod { get; set; }

    [Column("BGPeriodUnit")]
    [StringLength(50)]
    [Unicode(false)]
    public string? BgperiodUnit { get; set; }

    [Column("PBGAmount")]
    public double? Pbgamount { get; set; }

    [Column("PBGCreateDate", TypeName = "datetime")]
    public DateTime? PbgcreateDate { get; set; }

    [Column("PBGPeriod")]
    public int? Pbgperiod { get; set; }

    [Column("PBGPeriodUnit")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PbgperiodUnit { get; set; }

    public bool? DispatchedStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DispatchedDate { get; set; }

    public int? DispatchedQuantity { get; set; }

    public int? DispatchedBranchTo { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DispatchedRemark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ActualDeliveryDate { get; set; }

    public bool? DeliveredStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TrainingAndInstallationDate { get; set; }

    [Column("EMDConvertedTo")]
    public int? EmdconvertedTo { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DeliveredDocument { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DeliveredRemark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerInvoiceNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CustomerInvoiceDate { get; set; }

    public double? CustomerInvoiceAmount { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerInvoiceDocument { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerInvoiceRemark { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? EngineerInvoiceRemark { get; set; }

    public int? CustomerInvoiceStatus { get; set; }

    public int? InstallationStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InstallationDate { get; set; }

    public int? TrainingStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TrainingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReTrainingDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? InstTrainDocument { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? TrainingRemark { get; set; }

    public bool? CustomerPaymentStatus { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerPayment { get; set; }

    public double? CustomerTotalPayment { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerPaymentRemark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PrincipalPaymentStatus { get; set; }

    public double? PrincipalTotalPayment { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PrincipalPaymentRemark { get; set; }

    public int? FinalOrderStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FinalOrderClosingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RecoveryDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FinalOrderRemark { get; set; }

    public double? BadDebts { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? PrincipalPaymentProcessStatus { get; set; }

    public int? VerticalId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column("CustomerPONumber")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CustomerPonumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? AccountPerson { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AccountContactNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AccountEmailId { get; set; }

    public double? AmountDue { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Discount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalProductCost { get; set; }
}
