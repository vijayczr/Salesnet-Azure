using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LicenseTypeMaster")]
public partial class SnLicenseTypeMaster
{
    [Key]
    public int LicenseId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LicenseType { get; set; }
}
