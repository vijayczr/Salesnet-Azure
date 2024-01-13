using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class Master
{
    [Key]
    public int MasterId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MasterType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MasterValue { get; set; }

    public bool? IsActive { get; set; }
}
