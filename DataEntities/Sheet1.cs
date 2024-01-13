using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("Sheet1$")]
public partial class Sheet1
{
    [StringLength(255)]
    public string? CustomerName { get; set; }

    [StringLength(255)]
    public string? CustomerAddress1 { get; set; }

    [StringLength(255)]
    public string? CustomerAddress2 { get; set; }

    [StringLength(255)]
    public string? CustomerCity { get; set; }

    [StringLength(255)]
    public string? CustomerState { get; set; }

    [StringLength(255)]
    public string? CustomerCountry { get; set; }

    public double? CustomerZip { get; set; }

    public double? BranchId { get; set; }

    public double? VerticalId { get; set; }

    public double? SubVerticalId { get; set; }

    public double? CustomerPhone1 { get; set; }

    [StringLength(255)]
    public string? CustomerPhone2 { get; set; }

    [StringLength(255)]
    public string? CustomerMobile { get; set; }

    [StringLength(255)]
    public string? CustomerFax { get; set; }

    [StringLength(255)]
    public string? CustomerEmail { get; set; }

    public double? CustomerStatus { get; set; }

    public double? IsDeleted { get; set; }

    public double? CreatedBy { get; set; }

    [StringLength(255)]
    public string? CreatedOn { get; set; }

    [StringLength(255)]
    public string? ModifiedBy { get; set; }

    [StringLength(255)]
    public string? ModifiedOn { get; set; }
}
