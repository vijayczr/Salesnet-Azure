using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeAttachments")]
public partial class SnEmployeeAttachment
{
    [Key]
    public int EmpAttachmentId { get; set; }

    public int? EmpId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmpAttachmentName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? EmpAttachmentPath { get; set; }

    public bool? IsDeleted { get; set; }
}
