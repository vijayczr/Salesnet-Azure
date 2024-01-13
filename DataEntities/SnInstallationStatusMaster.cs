using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_InstallationStatusMaster")]
public partial class SnInstallationStatusMaster
{
    [Key]
    public int InstallationStatusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string InstallationStatus { get; set; } = null!;
}
