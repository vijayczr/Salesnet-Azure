using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_HRLoginCredentials")]
public partial class SnHrloginCredential
{
    [Key]
    public int TransId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UserId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Column("activedays")]
    public int? Activedays { get; set; }
}
