using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_LeadProducts")]
public partial class SnLeadProduct
{
    [Key]
    public int LeadProductsId { get; set; }

    public int? LeadId { get; set; }

    public int? ProductId { get; set; }

    public bool? IsDeleted { get; set; }
}
