using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("ArrivalDepartureMaster")]
public partial class ArrivalDepartureMaster
{
    public long? ArrivalDeptId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ArrivalFromTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArrivalDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ArrivalTime { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DepartureFromTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DepartureDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DepartureTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ToDate { get; set; }

    public int? EmpId { get; set; }
}
