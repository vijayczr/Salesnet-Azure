using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CallTypeMaster")]
public partial class SnCallTypeMaster
{
    [Key]
    public int CallTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CallType { get; set; }

    public bool? IsDeleted { get; set; }
}
