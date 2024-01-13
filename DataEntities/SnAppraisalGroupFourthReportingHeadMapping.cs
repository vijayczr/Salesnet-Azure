using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_AppraisalGroupFourthReportingHeadMapping")]
public partial class SnAppraisalGroupFourthReportingHeadMapping
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? FourthReportingHeadId { get; set; }

    public bool? IsActive { get; set; }
}
