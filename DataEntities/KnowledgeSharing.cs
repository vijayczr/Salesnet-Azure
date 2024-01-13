using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("KnowledgeSharing")]
public partial class KnowledgeSharing
{
    [Key]
    public int KnowledgeDocId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DocumentType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Subject { get; set; }

    [Column("KSDescription")]
    [Unicode(false)]
    public string? Ksdescription { get; set; }

    [Column("KSDocumentPath")]
    [StringLength(500)]
    [Unicode(false)]
    public string? KsdocumentPath { get; set; }

    [Column("KSDocumentStatus")]
    public int? KsdocumentStatus { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
