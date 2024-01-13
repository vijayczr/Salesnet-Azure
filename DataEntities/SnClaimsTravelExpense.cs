using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimsTravelExpenses")]
public partial class SnClaimsTravelExpense
{
    [Key]
    [Column("TravelExpensesID")]
    public int TravelExpensesId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TravelExpensesName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
