using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_BranchMaster")]
public partial class SnBranchMaster
{
    [Key]
    public int BranchId { get; set; }

    public int RegionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? BranchDescription { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchContactPerson { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchPhone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchMobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchFax { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BranchEmail { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? BranchAddress { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchCity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchState { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchCountry { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchZip { get; set; }

    public bool? BranchStatus { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
