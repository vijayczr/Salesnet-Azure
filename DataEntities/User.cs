using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class User
{
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserFirstName { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string UserLastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? UserPassword { get; set; }

    public int UserLoginId { get; set; }

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

    [Column("userlocation")]
    public int? Userlocation { get; set; }

    public int? UserType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserBirthDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserJoiningDate { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string UserRole { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UserAnniversaryDate { get; set; }

    public int? ReferredById { get; set; }

    [Column("ISActive")]
    public bool? Isactive { get; set; }

    [Unicode(false)]
    public string? UserImage { get; set; }

    [Column("branchname")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Branchname { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VerticalName { get; set; }

    [Column("MPolicyDetail")]
    [StringLength(500)]
    [Unicode(false)]
    public string? MpolicyDetail { get; set; }

    [Column("designationName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationName { get; set; }

    [Column("MPolicyExpiryDate")]
    [StringLength(30)]
    [Unicode(false)]
    public string? MpolicyExpiryDate { get; set; }
}
