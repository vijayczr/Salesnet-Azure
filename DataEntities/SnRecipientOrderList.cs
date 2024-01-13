using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_RecipientOrderList")]
public partial class SnRecipientOrderList
{
    [Key]
    public int Id { get; set; }

    public int? RecipientId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RecipientName { get; set; }

    [Column("RecipientEMailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RecipientEmailId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHeadEmailId { get; set; }

    [Column("ISREmailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? IsremailId { get; set; }

    public int? OrderId { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? EventType { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? OrderDeliveryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TrainingAndInstallationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDueDate { get; set; }

    public bool? DeliveryStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SendingDate { get; set; }
}
