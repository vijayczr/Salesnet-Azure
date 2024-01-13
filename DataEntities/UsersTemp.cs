using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
public partial class UsersTemp
{
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserFirstName { get; set; }

    public int UserLoginId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserPassword { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserEmailId { get; set; }

    [Column("reportingHead")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ReportingHead { get; set; }

    [Column("designationName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserContactNumber { get; set; }

    [Column("EmpCAddress")]
    [StringLength(500)]
    [Unicode(false)]
    public string? EmpCaddress { get; set; }

    [Column("EmpCCity")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCcity { get; set; }

    [Column("EmpCState")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCstate { get; set; }

    [Column("EmpCCountry")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCcountry { get; set; }

    [Column("EmpCPin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCpin { get; set; }

    [Column("EmpCPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCphone { get; set; }

    [Column("EmpPAddress")]
    [StringLength(500)]
    [Unicode(false)]
    public string? EmpPaddress { get; set; }

    [Column("EmpPCity")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPcity { get; set; }

    [Column("EmpPState")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPstate { get; set; }

    [Column("EmpPCountry")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPcountry { get; set; }

    [Column("EmpPPin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPpin { get; set; }

    [Column("EmpPPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPphone { get; set; }

    [Column("userlocation")]
    public int? Userlocation { get; set; }

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

    [Column("MPolicyName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MpolicyName { get; set; }

    [Column("MPolicyDetail")]
    [StringLength(500)]
    [Unicode(false)]
    public string? MpolicyDetail { get; set; }

    [Column("MPolicyExpiryDate")]
    [StringLength(30)]
    [Unicode(false)]
    public string? MpolicyExpiryDate { get; set; }

    [Column("MPolicySumAssured")]
    public double? MpolicySumAssured { get; set; }
}
