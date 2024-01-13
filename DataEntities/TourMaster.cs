using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("TourMaster")]
public partial class TourMaster
{
    [Key]
    public long TourId { get; set; }

    public int? EmpId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? From { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? To { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateFrom { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateTo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Purpose { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Station { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Mode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WeekStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WeekEndDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TicketCharges { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Boarding { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Lodging { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Conveyance { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PhoneFaxPhotoCopy { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Miscellaneous { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? BoardingRemark { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? LodgingRemark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Days { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Hours { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
