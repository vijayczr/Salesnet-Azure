using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CurrencyMaster")]
public partial class SnCurrencyMaster
{
    [Key]
    public int CurrencyTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Currency { get; set; }
}
