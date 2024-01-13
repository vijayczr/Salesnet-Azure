using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_HeadOffice")]
public partial class SnHeadOffice
{
    [Key]
    public int HeadOfficeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? HeadOfficeName { get; set; }
}
