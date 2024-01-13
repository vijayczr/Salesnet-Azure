using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_ApprasialFormEmployeeSectionRelationsship")]
public partial class SnApprasialFormEmployeeSectionRelationsship
{
    [Key]
    public int TransId { get; set; }

    [Column("FormEmployeeID")]
    public int FormEmployeeId { get; set; }

    public int SectionId { get; set; }

    public int QuestionId { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? EmployeeRating { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? ManagerRating { get; set; }

    [Column("COORating")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Coorating { get; set; }

    [Column("CEORating")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Ceorating { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? EmployeeComment { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ManagerComment { get; set; }

    [Column("COOComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Coocomment { get; set; }

    [Column("CEOComment")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Ceocomment { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
}
