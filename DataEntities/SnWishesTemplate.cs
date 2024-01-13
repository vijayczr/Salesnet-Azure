using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_WishesTemplate")]
public partial class SnWishesTemplate
{
    [Key]
    public int WishesTemplateId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WishesTemplateName { get; set; }

    [Unicode(false)]
    public string? WishesTemplateContent { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? WishesTemplateType { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsActive { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ImageName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ImagePath { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ImageContentId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
