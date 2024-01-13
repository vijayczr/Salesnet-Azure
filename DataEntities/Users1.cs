using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("Users1")]
public partial class Users1
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserFirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserLastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UserLogInId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UserEmailId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserContactNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? UserPassword { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserPicture { get; set; }

    public int? UserGroup { get; set; }

    public int? UserType { get; set; }

    public int? UserLocation { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UserRole { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserBirthDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserJoiningDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UserAnniversaryDate { get; set; }

    public int? ReferredById { get; set; }

    public bool? IsActive { get; set; }
}
