using System;
using System.Collections.Generic;

namespace POM.Models;

public partial class Log
{
    public int LogId { get; set; }

    public int UserId { get; set; }

    public string Activity { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
