using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("RecipientUsersList")]
public partial class RecipientUsersList
{
    [Key]
    public int Id { get; set; }

    [Column("User_Id")]
    public int UserId { get; set; }

    [Column("Recipient_Name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RecipientName { get; set; }

    [Column("Recipient_MailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? RecipientMailId { get; set; }

    [Column("Recipient_ContactNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecipientContactNo { get; set; }

    [Column("Sender_Name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? SenderName { get; set; }

    [Column("Sender_MailId")]
    [StringLength(100)]
    [Unicode(false)]
    public string? SenderMailId { get; set; }

    [Column("Special_UserName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? SpecialUserName { get; set; }

    [Column("Special_UserId")]
    public int? SpecialUserId { get; set; }

    [Column("Event_Type")]
    [StringLength(2)]
    [Unicode(false)]
    public string? EventType { get; set; }

    [Column("Delivery_Status")]
    public bool? DeliveryStatus { get; set; }

    [Column("Sending_Date", TypeName = "datetime")]
    public DateTime? SendingDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    public int? YearServed { get; set; }

    [Unicode(false)]
    public string? MedicalPolicyDetail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MedicalPolicyExpiryDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? JoiningDate { get; set; }

    [Column("designationName")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DesignationName { get; set; }

    [Unicode(false)]
    public string? WishesTemplateContent { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ImageContentId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ImageName { get; set; }
}
