using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Tenant
{
    public string TenantId { get; set; } = null!;

    public int BuildingCode { get; set; }

    public int ApartmentNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Balance { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public bool IsCommitee { get; set; }

    public virtual Building BuildingCodeNavigation { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
