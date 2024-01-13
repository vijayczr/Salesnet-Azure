using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_Customers_BKUP")]
public partial class SnCustomersBkup
{
    public int CustomerId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? CustomerAddress1 { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? CustomerAddress2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerCity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerState { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerCountry { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerZip { get; set; }

    public int? BranchId { get; set; }

    public int? VerticalId { get; set; }

    public int? SubVerticalId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerPhone1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerPhone2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerMobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerFax { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CustomerEmail { get; set; }

    public bool? CustomerStatus { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }
}
