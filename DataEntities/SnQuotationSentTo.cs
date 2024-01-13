using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SalesNet.Model;

[Keyless]
[Table("SN_QuotationSentTo")]
public partial class SnQuotationSentTo
{
    [Column("SNo")]
    public int Sno { get; set; }

    public int QuotationId { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string ContactMailIds { get; set; } = null!;

    [Column("DBContactMailIds")]
    [StringLength(8000)]
    [Unicode(false)]
    public string? DbcontactMailIds { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string? MailSubject { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? MailBody { get; set; }
}
