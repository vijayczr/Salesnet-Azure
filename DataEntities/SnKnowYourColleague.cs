using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_KnowYourColleague")]
public partial class SnKnowYourColleague
{
    [Key]
    public int ColleagueId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LinkName { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? DocumentPath { get; set; }
}
