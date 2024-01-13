using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_MasterUserType")]
public partial class SnMasterUserType
{
    [Key]
    public int UserTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserTypeName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? UserTypeDesc { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}
