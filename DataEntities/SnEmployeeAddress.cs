using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_EmployeeAddresses")]
public partial class SnEmployeeAddress
{
    [Key]
    public int EmpAddressId { get; set; }

    public int? EmpId { get; set; }

    public bool? IsPermanentAddress { get; set; }

    [Column("EmpPAddress")]
    [StringLength(500)]
    [Unicode(false)]
    public string? EmpPaddress { get; set; }

    [Column("EmpCAddress")]
    [StringLength(500)]
    [Unicode(false)]
    public string? EmpCaddress { get; set; }

    [Column("EmpPCity")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPcity { get; set; }

    [Column("EmpPState")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPstate { get; set; }

    [Column("EmpPCountry")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPcountry { get; set; }

    [Column("EmpPPin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPpin { get; set; }

    [Column("EmpPPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpPphone { get; set; }

    public bool? IsDeleted { get; set; }

    [Column("EmpCCity")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCcity { get; set; }

    [Column("EmpCState")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCstate { get; set; }

    [Column("EmpCCountry")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCcountry { get; set; }

    [Column("EmpCPin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCpin { get; set; }

    [Column("EmpCPhone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpCphone { get; set; }
}
