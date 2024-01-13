using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

public partial class TestAssignment
{
    [Key]
    public int AssignmentId { get; set; }

    public int? UserId { get; set; }

    public int? TestId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TestStartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TestEndTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TestdownloadTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TestUploadTime { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? TestUploadFilePath { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TestResult { get; set; }

    public int? ResultBy { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Teststatus { get; set; }

    public bool? IsActive { get; set; }
}
