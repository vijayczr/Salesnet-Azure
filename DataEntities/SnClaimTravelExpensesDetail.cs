using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_ClaimTravelExpensesDetails")]
public partial class SnClaimTravelExpensesDetail
{
    [Column("TravelExpensesDetailsID")]
    public int TravelExpensesDetailsId { get; set; }

    public int ClaimId { get; set; }

    [Column("TravelExpensesID")]
    public int TravelExpensesId { get; set; }

    public double Amount { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
