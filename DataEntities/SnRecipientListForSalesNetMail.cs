using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_RecipientListForSalesNetMail")]
public partial class SnRecipientListForSalesNetMail
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadName { get; set; }

    public int? EmployeeId { get; set; }

    public int? ReportingHeadId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadEmailId { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? EventType { get; set; }

    public bool? DeliveryStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SendingDate { get; set; }

    public bool? ReportingHeadActiveStatus { get; set; }
}
