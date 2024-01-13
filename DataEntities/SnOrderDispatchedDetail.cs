using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_OrderDispatchedDetails")]
public partial class SnOrderDispatchedDetail
{
    [Key]
    public int DispatchedId { get; set; }

    public int? OrderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AirwayBillNo { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CourierName { get; set; }

    public int? QtyOfBox { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DispatchedDate { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
