using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ApplicationHead")]
public partial class SnApplicationHead
{
    [Key]
    public int ApplicationHeadId { get; set; }

    public int EmployeeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string EmpName { get; set; } = null!;

    [Column("ASGFlag")]
    public bool Asgflag { get; set; }

    [Column("ISGFlag")]
    public bool Isgflag { get; set; }

    [Column("PSGFlag")]
    public bool Psgflag { get; set; }

    public bool Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public int? ModifiedBy { get; set; }
}
