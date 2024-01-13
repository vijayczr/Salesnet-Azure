using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class SpecialUser
{
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserFirstName { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string UserLastName { get; set; } = null!;

    public int UserLoginId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserPassword { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserEmailId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserContactNumber { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string UserPicture { get; set; } = null!;

    public int? UserGroup { get; set; }

    public int? UserType { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string UserRole { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UserBirthDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserJoiningDate { get; set; }

    [Column("userlocation")]
    public int? Userlocation { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserAnniversaryDate { get; set; }

    public int? ReferredById { get; set; }

    [Column("Event_Type")]
    [StringLength(2)]
    [Unicode(false)]
    public string EventType { get; set; } = null!;

    [Column("branchname")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Branchname { get; set; }

    public int? YearServed { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    [Column("MPolicyDetail")]
    [Unicode(false)]
    public string? MpolicyDetail { get; set; }

    [Column("MPolicyExpiryDate")]
    [StringLength(30)]
    [Unicode(false)]
    public string? MpolicyExpiryDate { get; set; }

    [Column("designationName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationName { get; set; }
}
