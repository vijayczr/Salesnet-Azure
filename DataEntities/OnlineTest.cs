using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class OnlineTest
{
    [Key]
    [Column("TestID")]
    public int TestId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TestCode { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? TestTitle { get; set; }

    public int? TestType { get; set; }

    [Unicode(false)]
    public string? TestDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TestValidUpto { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? TestFilePath { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
