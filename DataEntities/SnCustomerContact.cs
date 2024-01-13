using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Table("SN_CustomerContacts")]
[Index("CustContactId", "CustomerId", Name = "_dta_index_SN_CustomerContacts_49_738101670__K1_2_6_7")]
public partial class SnCustomerContact
{
    [Key]
    public int CustContactId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactPerson { get; set; }

    public int? CustDeptId { get; set; }

    public int? CustDesignationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactMobile { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactEmail { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactPhone { get; set; }

    public int? CustomerId { get; set; }

    public bool? ContactStatus { get; set; }

    public bool? IsDeleted { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CustDepartment { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CustDesignation { get; set; }
}
