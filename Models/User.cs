using System;
using System.Collections.Generic;
using pom1.Models;

namespace pom1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string EmailId { get; set; } = null!;

    public int? AadharCardNumber { get; set; }

    public int? PancardNumber { get; set; }

    public DateTime LastLoggedInDate { get; set; }

    public int CurrentLoginOtp { get; set; }

    public DateTime CreatedDate { get; set; }

    public string UserReferenceCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public bool IsActive { get; set; }

    public bool IsLoginBlocked { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Bank> Banks { get; } = new List<Bank>();

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<Reference> References { get; } = new List<Reference>();

    public virtual ICollection<UserTransaction> UserTransactionUserIdFromNavigations { get; } = new List<UserTransaction>();

    public virtual ICollection<UserTransaction> UserTransactionUserIdToNavigations { get; } = new List<UserTransaction>();
}
