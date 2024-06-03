﻿namespace BL.BlModels;

public class BlTenant
{
    public string TenantId { get; set; } = null!;

    public int BuildingCode { get; set; }

    public int ApartmentNumber { get; set; }

    //public string LastName { get; set; } = null!;

    //public string FirstName { get; set; } = null!;
    public string FullName { get; set; }  

    public string PhoneNumber { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Balance { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public bool IsCommitee { get; set; }

    public virtual BlBuilding BuildingCodeNavigation { get; set; } = null!;

    public virtual ICollection<BlProposal> Proposals { get; set; } = new List<BlProposal>();
}
