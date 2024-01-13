using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_SemesterMaster")]
public partial class SnSemesterMaster
{
    [Key]
    public int SemesterId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SemesterName { get; set; }

    public int? SemesterOrder { get; set; }

    public bool? IsDeleted { get; set; }
}
