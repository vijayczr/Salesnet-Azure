using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_DAROthersMapping")]
public partial class SnDarothersMapping
{
    [Key]
    [Column("DAROtherMapId")]
    public int DarotherMapId { get; set; }

    public int CategorisedOtherId { get; set; }

    [Column("DARId")]
    public int Darid { get; set; }
}
