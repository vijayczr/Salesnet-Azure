using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;
    
[Table("HRManuals")]
public partial class Hrmanual
{
    [Key]
    [Column("HRManualID")]
    public int HrmanualId { get; set; }

    public int? UserGroup { get; set; }

    public int? UserType { get; set; }

    public int? Department { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DocumentType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Subject { get; set; }

    [Column("HRDescription")]
    [Unicode(false)]
    public string? Hrdescription { get; set; }

    [Column("HRDocumentPath")]
    [StringLength(500)]
    [Unicode(false)]
    public string? HrdocumentPath { get; set; }

    [Column("HRDocumentStatus")]
    public int? HrdocumentStatus { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
