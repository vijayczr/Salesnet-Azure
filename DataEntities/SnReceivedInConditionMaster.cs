using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ReceivedInConditionMaster")]
public partial class SnReceivedInConditionMaster
{
    [Key]
    public int ReceivedInConditionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ReceivedInConditionStatus { get; set; }
}
