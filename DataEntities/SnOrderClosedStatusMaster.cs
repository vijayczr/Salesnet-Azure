using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderClosedStatusMaster")]
public partial class SnOrderClosedStatusMaster
{
    [Key]
    public int OrderClosedStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OrderClosedStatus { get; set; }
}
