using System;
using System.Collections.Generic;

namespace pom1.Models;

public partial class UserTransaction
{
    public int UserTransactionId { get; set; }

    public int UserIdFrom { get; set; }

    public int UserIdTo { get; set; }

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual User UserIdFromNavigation { get; set; } = null!;

    public virtual User UserIdToNavigation { get; set; } = null!;
}
