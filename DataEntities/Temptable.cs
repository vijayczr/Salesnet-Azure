using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("TEMPTABLE")]
public partial class Temptable
{
    [Column("TABLE_CATALOG")]
    [StringLength(128)]
    public string? TableCatalog { get; set; }

    [Column("TABLE_SCHEMA")]
    [StringLength(128)]
    public string? TableSchema { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(128)]
    public string TableName { get; set; } = null!;

    [Column("TABLE_TYPE")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TableType { get; set; }
}
