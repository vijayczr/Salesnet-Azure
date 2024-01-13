using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ReceivedMaster")]
public partial class SnReceivedMaster
{
    [Key]
    public int ReceivedId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ReceivedStatus { get; set; }
}
