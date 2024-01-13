using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PrincipalMaster")]
public partial class SnPrincipalMaster
{
    [Key]
    public int PrincipalId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? PrincipalName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PrincipalDescription { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PrincipalContactInfo { get; set; }

    public bool? PrincipalStatus { get; set; }

    public int? PrincipalCreditPeriod { get; set; }

    public bool? IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
