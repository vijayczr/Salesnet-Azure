using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_RegionMaster")]
public partial class SnRegionMaster
{
    [Key]
    public int RegionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RegionDescription { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionContactPerson { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionPhone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionMobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionFax { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RegionEmail { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RegionAddress { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionCity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionState { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionCountry { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RegionZip { get; set; }

    public bool? RegionStatus { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
