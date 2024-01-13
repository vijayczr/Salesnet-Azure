using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("users2")]
public partial class Users2
{
    [Column("userid")]
    public int Userid { get; set; }

    [Column("User_Id")]
    [StringLength(100)]
    [Unicode(false)]
    public string UserId1 { get; set; } = null!;

    [Column("Login_Id")]
    [StringLength(100)]
    [Unicode(false)]
    public string? LoginId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("passwrd")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Passwrd { get; set; }

    [Column("mobile")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Mobile { get; set; }

    [Column("user_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserStatus { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Designation { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Department { get; set; }

    [Column("DOB", TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    [Column("DOJ", TypeName = "datetime")]
    public DateTime? Doj { get; set; }

    [Column("Email_Id")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmailId { get; set; }

    [Column("Refered_By")]
    public int? ReferedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Anniversary { get; set; }

    public byte[]? Attachment { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Vertical { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
