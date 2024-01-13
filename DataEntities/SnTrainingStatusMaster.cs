using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_TrainingStatusMaster")]
public partial class SnTrainingStatusMaster
{
    [Key]
    public int TrainingStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TrainingStatus { get; set; } = null!;
}
