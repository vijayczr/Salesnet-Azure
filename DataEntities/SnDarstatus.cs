using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DARStatus")]
public partial class SnDarstatus
{
    [Key]
    public int DarstatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DarStatus { get; set; }

    public int? DarStatusOrder { get; set; }

    public bool? IsDeleted { get; set; }
}
