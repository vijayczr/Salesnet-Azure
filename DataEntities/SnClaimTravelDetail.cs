using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ClaimTravelDetails")]
public partial class SnClaimTravelDetail
{
    [Key]
    [Column("ClaimTravelDetailsID")]
    public int ClaimTravelDetailsId { get; set; }

    [Column("ClaimID")]
    public int ClaimId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? DepartureSource { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? DepartureDestination { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DepartureDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DepartureTime { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? ArrivalSource { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? ArrivalDestination { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ArrivalDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ArrivalTime { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
