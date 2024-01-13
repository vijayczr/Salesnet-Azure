using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_SavedSearch")]
public partial class SnSavedSearch
{
    [Key]
    public int SearchId { get; set; }

    public int? EmpId { get; set; }

    public int? CustId { get; set; }

    public int? LeadTypeId { get; set; }

    public int? CallTypeId { get; set; }

    public int? DarStageId { get; set; }

    public int? DarStatusId { get; set; }

    public int? LostReasonId { get; set; }

    public int? HeadOfficeId { get; set; }

    public int? RegionId { get; set; }

    public int? BranchId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? GroupText { get; set; }

    public int? ProductId { get; set; }

    public int? PrincipalId { get; set; }

    public int? VerticalId { get; set; }

    public int? SubVerticalId { get; set; }

    public int? CompetitorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    public int? EmpIdForSearch { get; set; }

    public int? PageSize { get; set; }
}
