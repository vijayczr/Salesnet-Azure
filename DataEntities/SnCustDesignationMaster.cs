using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CustDesignationMaster")]
[Index("CustDesignationId", Name = "ix_SN_CustDesignationMaster")]
public partial class SnCustDesignationMaster
{
    [Key]
    public int CustDesignationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustDesignationName { get; set; }

    public bool? IsDeleted { get; set; }
}
