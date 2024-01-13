using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sn_HolidayBak")]
public partial class SnHolidayBak
{
    [Column("HolidayID")]
    public int HolidayId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? HolidayName { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? HolidayDescription { get; set; }

    [Column(TypeName = "date")]
    public DateTime? HoliDayDate { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
