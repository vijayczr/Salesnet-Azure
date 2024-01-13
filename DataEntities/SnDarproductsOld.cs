using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("sn_Darproducts_old")]
public partial class SnDarproductsOld
{
    public int DarProductId { get; set; }

    public int? DarId { get; set; }

    public int? ProductId { get; set; }

    public bool? IsDeleted { get; set; }

    public double? DarProductPrice { get; set; }
}
