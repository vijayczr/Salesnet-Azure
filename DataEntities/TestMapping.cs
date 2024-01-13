using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("TestMapping")]
public partial class TestMapping
{
    [Key]
    public int TestMappingId { get; set; }

    public int? GroupId { get; set; }

    public int? TypeId { get; set; }

    public int? TestId { get; set; }

    public bool? IsActive { get; set; }
}
