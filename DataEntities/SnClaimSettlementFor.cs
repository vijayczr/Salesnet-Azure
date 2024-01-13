using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimSettlementFor")]
public partial class SnClaimSettlementFor
{
    [Key]
    [Column("ClaimSettlementForID")]
    public int ClaimSettlementForId { get; set; }

    [Column("ClaimSettlementID")]
    public int ClaimSettlementId { get; set; }

    [Column("ClaimID")]
    public int ClaimId { get; set; }

    public int? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
