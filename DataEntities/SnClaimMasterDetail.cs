using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimMasterDetails")]
public partial class SnClaimMasterDetail
{
    [Key]
    [Column("ClaimID")]
    public int ClaimId { get; set; }

    [Column("DARId")]
    public int Darid { get; set; }

    public int VoucherType { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string TourName { get; set; } = null!;

    public int EmployeeId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? SourcePlace { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? DestinationPlace { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? TourPurpose { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TravelMode { get; set; }

    public int? ClaimStatus { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? RejectionReason { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    public int? ApproveRejectedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ApproveRejectionDate { get; set; }

    public int? ClaimSettledBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClaimSettlementDate { get; set; }

    public int? NoofDays { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
