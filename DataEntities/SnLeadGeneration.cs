using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LeadGeneration")]
public partial class SnLeadGeneration
{
    [Key]
    public int LeadId { get; set; }

    public int? LeadTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LeadDate { get; set; }

    public int? EmpId { get; set; }

    public int? CustId { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsDeleted { get; set; }

    public int? LeadStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeadOrigin { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? LeadDescription { get; set; }

    [Column("ContactPersonID")]
    public int? ContactPersonId { get; set; }
}
