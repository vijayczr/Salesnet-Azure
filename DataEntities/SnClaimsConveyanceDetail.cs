using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimsConveyanceDetails")]
public partial class SnClaimsConveyanceDetail
{
    [Key]
    [Column("ConveyanceDetailsID")]
    public int ConveyanceDetailsId { get; set; }

    [Column("ClaimID")]
    public int ClaimId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TravelDate { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Source { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Destination { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TravelMode { get; set; }

    public double? Amount { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
