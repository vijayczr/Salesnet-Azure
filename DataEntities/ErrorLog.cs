using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("error_log")]
public partial class ErrorLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("error_message")]
    [Unicode(false)]
    public string? ErrorMessage { get; set; }
}
