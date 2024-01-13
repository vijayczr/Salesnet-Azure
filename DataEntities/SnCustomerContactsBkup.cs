using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_CustomerContacts_BKUP")]
public partial class SnCustomerContactsBkup
{
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
