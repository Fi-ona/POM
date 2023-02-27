using System;
using System.Collections.Generic;

namespace pom1.Models;

public partial class Bank
{
    public int BankId { get; set; }

    public int Upiid { get; set; }

    public string AccountHolderName { get; set; } = null!;

    public int AccountNumber { get; set; }

    public string BranchName { get; set; } = null!;

    public int BranchNumber { get; set; }

    public int PaymentType { get; set; }

    public decimal Balance { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
