using System;
using System.Collections.Generic;

namespace pom1.Models;

public partial class Reference
{
    public int ReferenceId { get; set; }

    public int UserId { get; set; }

    public string UserReferenceCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string UserTrace { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
