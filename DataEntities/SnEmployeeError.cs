using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_EmployeeError")]
public partial class SnEmployeeError
{
    [Column("EmployeeID")]
    public long? EmployeeId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ErrorDate { get; set; }
}
