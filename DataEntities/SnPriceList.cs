using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_PriceList")]
public partial class SnPriceList
{
    [Key]
    public int PriceListId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PriceListType { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? PriceDocumentPath { get; set; }
}
